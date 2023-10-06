using ETicaretAPI.application.Mediators.Commands.Basket.AddBasket;
using ETicaretAPI.application.Mediators.Commands.Basket.ConfirmBasket;
using ETicaretAPI.application.Mediators.Commands.Basket.DeleteInBasketProduct;
using ETicaretAPI.application.Mediators.Queries.Basket.GetBasketForUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("AddBasket")]
        public async Task<IActionResult> AddBasket([FromBody] AddBasketCommandRequest addBasketCommandRequest)
        {
            AddBasketCommandResponse response = await mediator.Send(addBasketCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteInBasketProduct")]
        public async Task<IActionResult> DeleteInBasketProduct([FromHeader] Guid Id)
        {
            DeleteInBasketProductCommandRequest deleteInBasketProductCommandRequest = new() { Id = Id };
            DeleteInBasketProductCommandResponse response = await mediator.Send(deleteInBasketProductCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("ConfirmBasket")]
        public async Task<IActionResult> ConfirmBasket([FromBody] ConfirmBasketCommandRequest confirmBasketCommandRequest)
        {
            ConfirmBasketCommandResponse response = await mediator.Send(confirmBasketCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBasketForUser")]
        public async Task<IActionResult> GetBasketForUser([FromQuery] GetBasketForUserCommandRequest getBasketForUserRequest)
        {
            GetBasketForUserCommandResponse response = await mediator.Send(getBasketForUserRequest);
            return Ok(response);
        }
    }
}
