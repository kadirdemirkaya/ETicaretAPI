using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.DTOs.Mail;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Commands.Basket.ConfirmBasket
{
    public class ConfirmBasketCommandHandler : IRequestHandler<ConfirmBasketCommandRequest, ConfirmBasketCommandResponse>
    {
        #region
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBasketReadRepository basketReadRepository;
        private readonly IBasketWriteRepository basketWriteRepository;
        private readonly IAppUserReadRepository appUserReadRepository;
        private readonly IOrderService orderService;
        private readonly IOrderReadRepository orderReadRepository;
        private readonly IBasketItemReadRepository basketItemReadRepository;
        private readonly IEmailService emailService;
        #endregion
        public ConfirmBasketCommandHandler(IHttpContextAccessor httpContextAccessor, IBasketReadRepository basketReadRepository, IAppUserReadRepository appUserReadRepository, IOrderService orderService, IBasketWriteRepository basketWriteRepository, IOrderReadRepository orderReadRepository, IBasketItemReadRepository basketItemReadRepository, IEmailService emailService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.basketReadRepository = basketReadRepository;
            this.appUserReadRepository = appUserReadRepository;
            this.orderService = orderService;
            this.basketWriteRepository = basketWriteRepository;
            this.orderReadRepository = orderReadRepository;
            this.basketItemReadRepository = basketItemReadRepository;
            this.emailService = emailService;
        }

        public async Task<ConfirmBasketCommandResponse> Handle(ConfirmBasketCommandRequest request, CancellationToken cancellationToken)
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser user = await appUserReadRepository.GetAsync(x => x.UserName == userName);

            Guid? orderId = await orderService.AddOrderWithRelations(request.AddOrderDto, request.AddAddressDto); // (!!!) - (?)

            ETicaretAPI.domain.Entites.Basket basket = await basketReadRepository.GetAsync(b => b.UserId == user.Id && b.IsSuccess == true);
            basket.isBasketConfirm = true;
            basket.OrderId = orderId;
            basket.IsSuccess = false;

            basketWriteRepository.UpdateAsync(basket); // ?

            List<BasketItem> basketItems = await basketItemReadRepository.GetAllAsync(bi => bi.BasketId == basket.Id && bi.IsSuccess == true);

            foreach (var bItem in basketItems)
            {
                bItem.IsSuccess = false;
            }

            await basketWriteRepository.SaveChangesAsync();

            var message = new Message(new string[] { user.Email }, "Basket Confirm", "<html><body><h1>Order</h1><p>Your order is confirmed !</p></body></html>");

            emailService.SendEmail(message);

            return new() { result = (orderId is not null ? true : false) };
        }
    }
}
