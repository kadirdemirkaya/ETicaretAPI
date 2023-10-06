using AutoMapper;
using ETicaretAPI.application.DTOs.Category;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetAllCategoryDto>().ReverseMap();
        }
    }
}
