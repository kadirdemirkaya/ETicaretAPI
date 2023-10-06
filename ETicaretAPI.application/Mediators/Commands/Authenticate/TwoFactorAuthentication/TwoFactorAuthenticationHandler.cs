using ETicaretAPI.application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.TwoFactorAuthentication
{
    public class TwoFactorAuthenticationHandler : IRequestHandler<TwoFactorAuthenticationRequest, TwoFactorAuthenticationResponse>
    {
        private readonly IAuthenticateService authenticateService;

        public TwoFactorAuthenticationHandler(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        public async Task<TwoFactorAuthenticationResponse> Handle(TwoFactorAuthenticationRequest request, CancellationToken cancellationToken)
        {
            var response = await authenticateService.LoginWithTFA(request.Code, request.Email);
            return new() { token = response.token, isSuccess = response.isSuccess };
        }
    }
}
