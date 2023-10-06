using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Category;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.UnitOfWorks;
using ETicaretAPI.domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryWriteRepository categoryWriteRepository, IUnitOfWork unitOfWork)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryProductDto>> CategoryInProductTotal()
        {
            var list = await unitOfWork.GetReadRepository<Category>().Table
                .Include(c => c.Products)
                .Select(c => new CategoryProductDto
                {
                    categoryName = c.Name,
                    totalProduct = c.Products.Count()
                }).ToListAsync();
            return list;
        }

        public async Task<bool> SeedCategory()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Name = "Food"
                },
                new Category
                {
                    Name = "Clothing"
                },
                new Category
                {
                    Name = "Phone"
                },
                new Category
                {
                    Name = "Computer"
                },
                new Category
                {
                    Name = "Book"
                },
                new Category
                {
                    Name = "Furniture"
                },
                new Category
                {
                    Name = "Shoe"
                }
            };

            bool result = await categoryWriteRepository.AddRangeAsync(categories);
            await categoryWriteRepository.SaveChangesAsync();
            return true;
        }
    }
}
