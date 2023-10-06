using AutoMapper;
using ETicaretAPI.application.DTOs.Authenticate;
using ETicaretAPI.application.Mediators.Commands.Authenticate.Register;
using ETicaretAPI.domain.Entites.Identity;

namespace ETicaretAPI.application.Mappers.Authenticate
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterCommandRequest, RegisterDto>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.RegisterDto.Email))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.RegisterDto.Gender))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.RegisterDto.Password))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.RegisterDto.PhoneNumber))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.RegisterDto.UserName))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.RegisterDto.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.RegisterDto.LastName)).ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}
