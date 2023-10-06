using ETicaretAPI.application.DTOs.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.Register
{
    public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
    {
        public RegisterDto RegisterDto { get; set; }
        public IFormFile? files { get; set; }
    }
}
