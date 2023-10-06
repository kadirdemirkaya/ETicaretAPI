using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductToBasket(Guid userId);
    }
}
