using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace ETicaretAPI.application.Mediators.Queries.Order.GetActiveOrders
{
    public class GetActiveOrdersQueryHandler : IRequestHandler<GetActiveOrdersQueryRequest, GetActiveOrdersQueryResponse>
    {
        private readonly ICustomerReadRepository customerReadRepository;
        private readonly IOrderReadRepository orderReadRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserReadRepository appUserReadRepository;
        private readonly IOrderService orderService;

        public GetActiveOrdersQueryHandler(ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository, IHttpContextAccessor httpContextAccessor, IAppUserReadRepository appUserReadRepository, IOrderService orderService)
        {
            this.customerReadRepository = customerReadRepository;
            this.orderReadRepository = orderReadRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.appUserReadRepository = appUserReadRepository;
            this.orderService = orderService;
        }

        public async Task<GetActiveOrdersQueryResponse> Handle(GetActiveOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            List<ETicaretAPI.domain.Entites.Order> orders = await orderService.GetActiveOrNotActiveOrdersAsync(true);
            return new() { Orders = orders };
        }
    }
}
