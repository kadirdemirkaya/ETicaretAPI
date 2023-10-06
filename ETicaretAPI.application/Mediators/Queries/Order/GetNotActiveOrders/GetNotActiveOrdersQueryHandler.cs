using ETicaretAPI.application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.application.Mediators.Queries.Order.GetNotActiveOrders
{
    public class GetNotActiveOrdersQueryHandler : IRequestHandler<GetNotActiveOrdersQueryRequest, GetNotActiveOrdersQueryResponse>
    {
        private readonly IOrderService orderService;

        public GetNotActiveOrdersQueryHandler(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<GetNotActiveOrdersQueryResponse> Handle(GetNotActiveOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            List<ETicaretAPI.domain.Entites.Order> orders = await orderService.GetActiveOrNotActiveOrdersAsync(false);
            return new() { Orders = orders };
        }
    }
}
