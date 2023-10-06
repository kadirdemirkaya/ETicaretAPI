using ETicaretAPI.application.DTOs.Address;
using ETicaretAPI.application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Basket.ConfirmBasket
{
    public class ConfirmBasketCommandRequest : IRequest<ConfirmBasketCommandResponse>
    {
        public AddAddressDto AddAddressDto { get; set; }
        public AddOrderDto AddOrderDto { get; set; }
    }
}
