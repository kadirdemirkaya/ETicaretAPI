using ETicaretAPI.application.DTOs.Address;
using ETicaretAPI.application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Order.AddOrder
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {
        public AddOrderDto AddOrderDto { get; set; }
        public AddAddressDto AddAddressDto { get; set; }
    }
}
