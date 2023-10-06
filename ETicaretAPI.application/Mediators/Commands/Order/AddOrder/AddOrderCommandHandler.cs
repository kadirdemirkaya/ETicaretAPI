using ETicaretAPI.application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Order.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IOrderService orderService;

        public AddOrderCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Guid result = await orderService.AddOrderWithRelations(request.AddOrderDto, request.AddAddressDto);
            return new() { result = result };
        }
    }
}
