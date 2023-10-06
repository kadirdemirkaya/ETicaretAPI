using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Repositories
{
    public interface IBasketReadRepository : IReadRepository<Basket>
    {
        Task<Basket> GetLastBasket(Guid UserId);
    }
}
