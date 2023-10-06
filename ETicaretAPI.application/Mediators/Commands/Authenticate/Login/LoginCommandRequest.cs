using ETicaretAPI.application.DTOs.Authenticate;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public LoginDto LoginDto { get; set; }
    }
}
