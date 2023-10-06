using ETicaretAPI.application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.User.UserDeletePhoto
{
    public class UserDeletePhotoCommandHandler : IRequestHandler<UserDeletePhotoCommandRequest, UserDeletePhotoCommandResponse>
    {
        private readonly IImageService imageService;

        public UserDeletePhotoCommandHandler(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<UserDeletePhotoCommandResponse> Handle(UserDeletePhotoCommandRequest request, CancellationToken cancellationToken)
        {
            bool response = await imageService.UserProfilePhotoDeleteAsync();
            return new() { result = response };
        }
    }
}
