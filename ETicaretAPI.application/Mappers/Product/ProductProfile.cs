using AutoMapper;
using ETicaretAPI.application.DTOs.Product;
using ETicaretAPI.application.Mediators.Commands.Product.CreateProduct;
using ETicaretAPI.application.Mediators.Commands.Product.CreateRangeProduct;
using ETicaretAPI.application.Mediators.Commands.Product.ProductDelete;
using ETicaretAPI.application.Mediators.Commands.Product.ProductUpdate;
using ETicaretAPI.application.Mediators.Queries.Product.GetProductIdWithCode;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>()
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.AddProductDto.Stock))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.AddProductDto.Price))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AddProductDto.Name)).ReverseMap();
            CreateMap<AddProductDto, Product>().ReverseMap();


            CreateMap<CreateRangeProductCommandRequest, List<Product>>().ReverseMap();
            CreateMap<AddProductDto, Product>().ReverseMap();

            CreateMap<GellAllProductDto, Product>().ReverseMap();
            CreateMap<GetProductByGuidDto, Product>().ReverseMap();
            

            CreateMap<ProductUpdateCommandRequest, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
           

            CreateMap<ProductDeleteCommandRequest, Product>().ReverseMap();
            CreateMap<DeleteProductDto, Product>().ReverseMap();

            CreateMap<GetProductWithCodeQueryRequest, Product>().ReverseMap();
            CreateMap<GetProductWithCodeDto, Product>().ReverseMap();

            CreateMap<GetProductIdDto, Product>().ReverseMap();
        }
    }
}
