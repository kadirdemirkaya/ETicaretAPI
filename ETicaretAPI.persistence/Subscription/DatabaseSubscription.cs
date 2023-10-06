using ETicaretAPI.application.DTOs.Category;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.persistence.Data;
using ETicaretAPI.persistence.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TableDependency.SqlClient;

namespace ETicaretAPI.persistence.Subscription
{
    public class DatabaseSubscription<T> : IDatabaseSubscription where T : class, new()
    {
        SqlTableDependency<T> _tableDependency;
        IHubContext<ProductHub> _hubContext;
        private readonly ETicaretAPIProjectDbContext _context;

        public DatabaseSubscription(IHubContext<ProductHub> hubContext, ETicaretAPIProjectDbContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(Configurations.Configuration.ConnectionString, tableName);
            _tableDependency.OnChanged += async (o, e) =>
            {
                var categoryProduct = await _context.Categories
                    .Select(category => new CategoryProductDto
                    {
                        categoryName = category.Name,
                        totalProduct = category.Products.Count()
                    })
                    .ToListAsync();
                await _hubContext.Clients.All.SendAsync("receiveProduct", categoryProduct);
            };
            _tableDependency.OnError += (o, e) =>
            {

            };
            _tableDependency.Start();
        }
        ~DatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
