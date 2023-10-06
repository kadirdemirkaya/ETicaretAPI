using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Commands.Basket.AddBasket
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, AddBasketCommandResponse>
    {
        private readonly IBasketWriteRepository basketWriteRepository;
        private readonly IBasketReadRepository basketReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserReadRepository appUserReadRepository;
        private readonly IBasketItemWriteRepository basketItemWriteRepository;
        private readonly IBasketItemReadRepository basketItemReadRepository;

        public AddBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IProductWriteRepository productWriteRepository, IHttpContextAccessor httpContextAccessor, IAppUserReadRepository appUserReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketReadRepository basketReadRepository, IBasketItemReadRepository basketItemReadRepository)
        {
            this.basketWriteRepository = basketWriteRepository;
            this.productWriteRepository = productWriteRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.appUserReadRepository = appUserReadRepository;
            this.basketItemWriteRepository = basketItemWriteRepository;
            this.basketReadRepository = basketReadRepository;
            this.basketItemReadRepository = basketItemReadRepository;
        }

        public async Task<AddBasketCommandResponse> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            //1
            string name = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser user = await appUserReadRepository.GetAsync(a => a.UserName == name);

            ETicaretAPI.domain.Entites.Basket? existsBasket = await basketReadRepository.GetLastBasket(user.Id);

            if (existsBasket is null)
            {
                ETicaretAPI.domain.Entites.Basket basket = new() { UserId = user.Id, isBasketConfirm = false, IsSuccess = true };
                await basketWriteRepository.AddAsync(basket);
                await basketWriteRepository.SaveChangesAsync();

                BasketItem basketItem2 = new() { BasketId = basket.Id, ProductId = request.ProductId, Quantity = request.Quantity, IsSuccess = true };
                await basketItemWriteRepository.AddAsync(basketItem2);
                await basketItemWriteRepository.SaveChangesAsync();
                return new() { result = true };
            }
            else if (existsBasket is not null)
            {
                //şimdi sıkıntı eski ürününe ekleme yapıyor yeni olarak eklimiyor
                BasketItem basketItem3 = await basketItemReadRepository.GetAsync(bi => bi.ProductId == request.ProductId && bi.BasketId == existsBasket.Id);

                if (basketItem3 is not null)
                {
                    int quantity = request.Quantity;
                    basketItem3.Quantity = quantity;
                    await basketItemWriteRepository.SaveChangesAsync();
                    return new() { result = true };
                }
                else
                {
                    BasketItem basketItem4 = new() { BasketId = existsBasket.Id, ProductId = request.ProductId, Quantity = request.Quantity, IsSuccess = true };
                    await basketItemWriteRepository.AddAsync(basketItem4);
                    await basketItemWriteRepository.SaveChangesAsync();
                    return new() { result = true };
                }
            }
            return new() { result = false };
        }
    }
}
