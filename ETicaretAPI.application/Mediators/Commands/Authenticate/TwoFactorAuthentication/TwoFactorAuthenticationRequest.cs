using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.TwoFactorAuthentication
{
    public class TwoFactorAuthenticationRequest : IRequest<TwoFactorAuthenticationResponse>
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
