using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Commands.User.UserAssignPhoto
{
    public class UserAssignPhotoCommandRequest : IRequest<UserAssignPhotoCommandResponse>
    {
        public IFormFile file { get; set; }
    }
}
