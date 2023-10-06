using ETicaretAPI.application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Order.CancelToOrderById
{
    public class CancelToOrderByIdCommandHandler : IRequestHandler<CancelToOrderByIdCommandRequest, CancelToOrderByIdCommandResponse>
    {
        private readonly IOrderService orderService;

        public CancelToOrderByIdCommandHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<CancelToOrderByIdCommandResponse> Handle(CancelToOrderByIdCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await orderService.CancelToOrder(request.OrderId);
            return new() { result = result };
        }
    }
}
