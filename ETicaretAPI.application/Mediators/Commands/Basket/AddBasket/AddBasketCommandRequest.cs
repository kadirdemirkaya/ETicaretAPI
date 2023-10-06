using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Basket.AddBasket
{
    public class AddBasketCommandRequest : IRequest<AddBasketCommandResponse>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
