using ETicaretAPI.application.Mediators.Commands.User.UserAssignPhoto;
using ETicaretAPI.application.Mediators.Commands.User.UserDeletePhoto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("UserAssignPhoto")]
        public async Task<IActionResult> UserAssignPhoto([FromForm] UserAssignPhotoCommandRequest userAssignPhotoCommandRequest)
        {
            UserAssignPhotoCommandResponse response = await mediator.Send(userAssignPhotoCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("UserDeletePhoto")]
        public async Task<IActionResult> UserDeletePhoto([FromQuery]UserDeletePhotoCommandRequest userDeletePhotoCommandRequest)
        {
            UserDeletePhotoCommandResponse response = await mediator.Send(userDeletePhotoCommandRequest);
            return Ok(response);
        }
    }
}
