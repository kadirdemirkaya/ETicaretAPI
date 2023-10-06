using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.Statics;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.application.Mediators.Commands.Communication.CommunicationCreate
{
    public class CommunicationCreateCommandHandler : IRequestHandler<CommunicationCreateCommandRequest, CommunicationCreateCommandResponse>
    {
        private readonly ICommunicationCustomerPersonWriteRepository communicationCustomerPersonWriteRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly ICommunicationHubService communicationHubService;
        private readonly ICommunicationPersonReadRepository communicationPersonReadRepository;

        public CommunicationCreateCommandHandler(ICommunicationCustomerPersonWriteRepository communicationCustomerPersonWriteRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ICommunicationHubService communicationHubService, ICommunicationPersonReadRepository communicationPersonReadRepository, RoleManager<AppRole> roleManager)
        {
            this.communicationCustomerPersonWriteRepository = communicationCustomerPersonWriteRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.communicationHubService = communicationHubService;
            this.communicationPersonReadRepository = communicationPersonReadRepository;
        }

        public async Task<CommunicationCreateCommandResponse> Handle(CommunicationCreateCommandRequest request, CancellationToken cancellationToken)
        {
            //User(Customer)
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser? appUser = await userManager.FindByNameAsync(userName);
            StaticPropertiesApp.AppUserId = appUser.Id;

            //CommunicationPerson
            Guid cPersonId = Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81");

            //CommunicationCustomerPerson
            bool result2 = await communicationCustomerPersonWriteRepository.AddAsync(new() { CommunicationPersonId = cPersonId, AppUserId = StaticPropertiesApp.AppUserId });

            await communicationCustomerPersonWriteRepository.SaveChangesAsync();

            await communicationHubService.SendDataForUser();
            await communicationHubService.SendDataForPerson();

            await communicationHubService.SendMessageForPerson("Started New Speak !!!");

            return new() { isSuccess = result2 };
        }
    }
}
