using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Commands.Basket.DeleteInBasketProduct
{
    public class DeleteInBasketProductCommandRequest : IRequest<DeleteInBasketProductCommandResponse>
    {
        [FromHeader]
        public Guid Id { get; set; }
    }
}
