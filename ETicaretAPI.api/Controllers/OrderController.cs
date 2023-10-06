using ETicaretAPI.application.Mediators.Commands.Order.AddOrder;
using ETicaretAPI.application.Mediators.Commands.Order.CancelToOrderById;
using ETicaretAPI.application.Mediators.Queries.Order.GetActiveOrderInfos;
using ETicaretAPI.application.Mediators.Queries.Order.GetActiveOrders;
using ETicaretAPI.application.Mediators.Queries.Order.GetNotActiveOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder(AddOrderCommandRequest addOrderCommandRequest)
        {
            AddOrderCommandResponse response = await mediator.Send(addOrderCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetActiveOrders")]
        public async Task<IActionResult> GetActiveOrders([FromQuery] GetActiveOrdersQueryRequest getActiveOrdersQueryRequest)
        {
            GetActiveOrdersQueryResponse response = await mediator.Send(getActiveOrdersQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetNotActiveOrders")]
        public async Task<IActionResult> GetNotActiveOrders([FromQuery] GetNotActiveOrdersQueryRequest getNotActiveOrdersQueryRequest)
        {
            GetNotActiveOrdersQueryResponse response = await mediator.Send(getNotActiveOrdersQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetActiveOrderInfos")]
        public async Task<IActionResult> GetActiveOrderInfos([FromHeader] GetActiveOrderInfosQueryRequest getActiveOrdersQueryRequest)
        {
            GetActiveOrderInfosQueryResponse response = await mediator.Send(getActiveOrdersQueryRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("CancelToOrderById")]
        public async Task<IActionResult> CancelToOrderById([FromHeader] Guid Id)
        {
            CancelToOrderByIdCommandRequest cancelToOrderByIdCommandRequest = new() { OrderId = Id };
            CancelToOrderByIdCommandResponse response = await mediator.Send(cancelToOrderByIdCommandRequest);
            return Ok(response);
        }
    }
}
