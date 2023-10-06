using ETicaretAPI.application.Mediators.Commands.Chat.MessageCreate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IMediator mediator;

        public ChatController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("MessageCreateAsync")]
        public async Task<IActionResult> MessageCreateAsync(MessageCreateCommandRequest messageCreateCommandRequest)
        {
            MessageCreateCommandResponse response = await mediator.Send(messageCreateCommandRequest);
            return Ok(response);
        }
    }
}
