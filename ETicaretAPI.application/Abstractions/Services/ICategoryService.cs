using ETicaretAPI.application.DTOs.Category;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<bool> SeedCategory();

        Task<List<CategoryProductDto>> CategoryInProductTotal();
    }
}
