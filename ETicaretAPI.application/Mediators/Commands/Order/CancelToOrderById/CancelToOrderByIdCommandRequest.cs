using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Commands.Order.CancelToOrderById
{
    public class CancelToOrderByIdCommandRequest : IRequest<CancelToOrderByIdCommandResponse>
    {
        [FromHeader]
        public Guid OrderId { get; set; }
    }
}
