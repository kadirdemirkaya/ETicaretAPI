using ETicaretAPI.persistence.Configurations;
using ETicaretAPI.persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ETicaretAPI.persistence
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<ETicaretAPIProjectDbContext>
    {
        public ETicaretAPIProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretAPIProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
