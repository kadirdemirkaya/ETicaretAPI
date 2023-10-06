using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Category;
using MediatR;

namespace ETicaretAPI.application.Mediators.Queries.Category.ProductTotalOfCategories
{
    public class ProductTotalOfCategoriesHandler : IRequestHandler<ProductTotalOfCategoriesRequest, ProductTotalOfCategoriesResponse>
    {
        private readonly ICategoryService categoryService;

        public ProductTotalOfCategoriesHandler(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<ProductTotalOfCategoriesResponse> Handle(ProductTotalOfCategoriesRequest request, CancellationToken cancellationToken)
        {
            List<CategoryProductDto> response = await categoryService.CategoryInProductTotal();
            return new() { CategoryProductDtos = response };
        }
    }
}
