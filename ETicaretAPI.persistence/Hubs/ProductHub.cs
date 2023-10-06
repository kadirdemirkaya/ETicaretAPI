using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Category;
using ETicaretAPI.application.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.persistence.Hubs
{
    public class ProductHub : Hub
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly ICategoryService categoryService;

        public ProductHub(ICategoryReadRepository categoryReadRepository, ICategoryService categoryService)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.categoryService = categoryService;
        }                                                        

        public async Task SendCategoryQuantity()                
        {
            List<CategoryProductDto> categories = await categoryService.CategoryInProductTotal();
            await Clients.All.SendAsync("receiveProduct", "MERHABA");
        }
    }
}
