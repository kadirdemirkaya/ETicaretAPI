using AutoMapper;
using ETicaretAPI.application.DTOs.Address;
using ETicaretAPI.application.DTOs.Order;
using ETicaretAPI.application.Mediators.Commands.Order.AddOrder;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddOrderCommandRequest, AddOrderDto>().ReverseMap();
            CreateMap<AddOrderCommandRequest, AddAddressDto>().ReverseMap();
            CreateMap<AddOrderDto, Order>().ReverseMap();
            CreateMap<AddAddressDto, Address>().ReverseMap();
        }
    }
}
