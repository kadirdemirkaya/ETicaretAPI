using AutoMapper;
using ETicaretAPI.application.DTOs.Communication;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Mappers.Communication
{
    public class CommunicationProfile : Profile
    {
        public CommunicationProfile()
        {
            CreateMap<CommunicationCustomerPerson, CommunicationForUserDto>().ReverseMap();

            CreateMap<CommunicationPerson, CommunicationForUserDto>().ReverseMap();
            CreateMap<CommunicationCustomerPerson, CommunicationForUserDto>().ReverseMap();
            CreateMap<CommunicationCustomerPerson, List<CommunicationForPersonDto>>().ReverseMap();
            CreateMap<CommunicationCustomerPerson, CommunicationForPersonDto>();

        }
    }
}
