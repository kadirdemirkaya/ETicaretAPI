using AutoMapper;
using ETicaretAPI.application.DTOs.Authenticate;
using ETicaretAPI.application.Mediators.Commands.Authenticate.Login;

namespace ETicaretAPI.application.Mappers.Authenticate
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginCommandRequest, LoginDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.LoginDto.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.LoginDto.Password)).ReverseMap();
        }
    }
}
