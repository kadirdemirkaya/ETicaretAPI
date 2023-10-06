using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Queries.Order.GetActiveOrderInfos
{
    public class GetActiveOrderInfosQueryHandler : IRequestHandler<GetActiveOrderInfosQueryRequest, GetActiveOrderInfosQueryResponse>
    {
        private readonly IOrderService orderService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserReadRepository appUserReadRepository;

        public GetActiveOrderInfosQueryHandler(IOrderService orderService, IHttpContextAccessor httpContextAccessor, IAppUserReadRepository appUserReadRepository)
        {
            this.orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
            this.appUserReadRepository = appUserReadRepository;
        }

        public async Task<GetActiveOrderInfosQueryResponse> Handle(GetActiveOrderInfosQueryRequest request, CancellationToken cancellationToken)
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser appUser = await appUserReadRepository.GetAsync(a => a.UserName == userName);
            var orders = await orderService.GetUserActiveOrders(appUser.Id,request.OrderId);
            return new() { ActiveOrdersDtos = orders };
        }
    }
}
