using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection.PortableExecutable;

namespace ETicaretAPI.application.Mediators.Commands.Basket.DeleteInBasketProduct
{
    public class DeleteInBasketProductCommandHandler : IRequestHandler<DeleteInBasketProductCommandRequest, DeleteInBasketProductCommandResponse>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAppUserReadRepository appUserReadRepository;
        private readonly IBasketItemReadRepository basketItemReadRepository;
        private readonly IBasketReadRepository basketReadRepository;
        private readonly IBasketItemWriteRepository basketItemWriteRepository;
        public DeleteInBasketProductCommandHandler(IHttpContextAccessor httpContextAccessor, IAppUserReadRepository appUserReadRepository, IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository, IBasketItemWriteRepository basketItemWriteRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.appUserReadRepository = appUserReadRepository;
            this.basketItemReadRepository = basketItemReadRepository;
            this.basketReadRepository = basketReadRepository;
            this.basketItemWriteRepository = basketItemWriteRepository;
        }

        public async Task<DeleteInBasketProductCommandResponse> Handle(DeleteInBasketProductCommandRequest request, CancellationToken cancellationToken)
        {
            string name = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser user = await appUserReadRepository.GetAsync(a => a.UserName == name);

            ETicaretAPI.domain.Entites.Basket basket = await basketReadRepository.GetAsync(b => b.UserId == user.Id && b.IsSuccess == true && b.isBasketConfirm == false);
            BasketItem basketItem = await basketItemReadRepository.GetAsync(bi => bi.BasketId == basket.Id && bi.ProductId == request.Id);
            basketItem.IsSuccess = false;
            basketItem.DeletedTime = DateTime.Now;

            await basketItemWriteRepository.SaveChangesAsync();

            return new() { result = basketItem is not null ? true : false };
        }
    }
}
