using AutoMapper;
using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Authenticate;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticateService _authenticateService;
        private readonly IAuthenticationHubService authenticationHubService;
        public LoginCommandHandler(IMapper mapper, IAuthenticateService authenticateService, IAuthenticationHubService authenticationHubService)
        {
            _mapper = mapper;
            _authenticateService = authenticateService;
            this.authenticationHubService = authenticationHubService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<LoginDto>(request);
            var response = await _authenticateService.LoginAsync(map);
            if (response.isSuccess)
                await authenticationHubService.LoginMessageAsync("Login Process Succesfully");
            return new() { token = response.token, isSuccess = response.isSuccess, TFA = response.TFA };
        }
    }
}
