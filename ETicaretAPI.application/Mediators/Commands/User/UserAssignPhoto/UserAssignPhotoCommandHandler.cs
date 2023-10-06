using ETicaretAPI.application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Mediators.Commands.User.UserAssignPhoto
{
    public class UserAssignPhotoCommandHandler : IRequestHandler<UserAssignPhotoCommandRequest, UserAssignPhotoCommandResponse>
    {
        private readonly IImageService imageService;

        public UserAssignPhotoCommandHandler(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<UserAssignPhotoCommandResponse> Handle(UserAssignPhotoCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await imageService.UserProfilePhotoAddAsync(request.file);
            return new() { result = result };
        }
    }
}
