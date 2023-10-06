using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ETicaretAPI.persistence.Repositories
{
    public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
    {
        private readonly ETicaretAPIProjectDbContext context;
        public BasketReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Basket> GetLastBasket(Guid UserId)
        {
            var lastBasket = await context.Set<Basket>()
                                  .Where(b => b.UserId == UserId && b.isBasketConfirm == false && b.IsSuccess == true)
                                  .OrderByDescending(b => b.CreatedDate)
                                  .FirstOrDefaultAsync();
            return lastBasket;
        }
    }
}
