using AutoMapper;
using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Authenticate;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Authenticate.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public RegisterCommandHandler(IAuthenticateService authenticateService, IMapper mapper, IImageService imageService)
        {
            _authenticateService = authenticateService;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<RegisterDto>(request);
            var response = await _authenticateService.RegisterAsync(map);
            if (response)
                return new() { response = true };
            return new() { response = false };
        }
    }
}
