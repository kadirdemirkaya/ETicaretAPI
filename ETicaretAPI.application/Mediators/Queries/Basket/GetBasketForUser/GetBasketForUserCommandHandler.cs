using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Queries.Basket.GetBasketForUser
{
    public class GetBasketForUserCommandHandler : IRequestHandler<GetBasketForUserCommandRequest, GetBasketForUserCommandResponse>
    {
        private readonly IBasketReadRepository basketReadRepository;
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserReadRepository appUserReadRepository;
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductService productService;

        public GetBasketForUserCommandHandler(IUserService userServices, IBasketReadRepository basketReadRepository, IHttpContextAccessor httpContextAccessor, IAppUserReadRepository appUserReadRepository, IProductReadRepository productReadRepository, IProductService productService)
        {
            this.userService = userService;
            this.basketReadRepository = basketReadRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.appUserReadRepository = appUserReadRepository;
            this.productReadRepository = productReadRepository;
            this.productService = productService;
        }

        public async Task<GetBasketForUserCommandResponse> Handle(GetBasketForUserCommandRequest request, CancellationToken cancellationToken)
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser appUser = await appUserReadRepository.GetAsync(a => a.UserName == userName);

            var products = await productService.GetProductToBasket(appUser.Id);

            return new() { Products = products };
        }
    }
}
