using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.Statics;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.application.Mediators.Commands.Communication.CommunicationEnd
{
    public class CommunicationEndCommandHandler : IRequestHandler<CommunicationEndCommandRequest, CommunicationEndCommandResponse>
    {
        private readonly ICommunicationCustomerPersonWriteRepository communicationCustomerPersonWriteRepository;
        private readonly ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICommunicationHubService communicationHubService;
        private readonly ICommunicationMessageWriteRepository communicationMessageWriteRepository;
        private readonly ICommunicationMessageReadRepository communicationMessageReadRepository;
        public CommunicationEndCommandHandler(ICommunicationCustomerPersonWriteRepository communicationCustomerPersonWriteRepository, ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, ICommunicationHubService communicationHubService, ICommunicationMessageWriteRepository communicationMessageWriteRepository, ICommunicationMessageReadRepository communicationMessageReadRepository)
        {
            this.communicationCustomerPersonWriteRepository = communicationCustomerPersonWriteRepository;
            this.communicationCustomerPersonReadRepository = communicationCustomerPersonReadRepository;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.communicationHubService = communicationHubService;
            this.communicationMessageWriteRepository = communicationMessageWriteRepository;
            this.communicationMessageReadRepository = communicationMessageReadRepository;
        }

        public async Task<CommunicationEndCommandResponse> Handle(CommunicationEndCommandRequest request, CancellationToken cancellationToken)
        {
            //User(Customer)
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser? appUser = await userManager.FindByNameAsync(userName);
            StaticPropertiesApp.AppUserId = appUser.Id;

            //CommunicationCustomerPerson
            Guid cPersonId = Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81");
            var cCustomerPerson = await communicationCustomerPersonReadRepository.GetAsync(cp => cp.CommunicationPersonId == cPersonId && cp.AppUserId == StaticPropertiesApp.AppUserId && cp.IsSuccess == true);

            CommunicationMessage cMessage = await communicationMessageReadRepository.GetAsync(cm => cm.CommunicationCustomerPersonId == cCustomerPerson.Id && cm.IsSuccess == true);
            if (cMessage is not null)
                communicationMessageWriteRepository.Delete(cMessage); // !

            communicationCustomerPersonWriteRepository.Delete(cCustomerPerson);

            await communicationCustomerPersonWriteRepository.SaveChangesAsync();

            await communicationHubService.SendDataForUser();
            await communicationHubService.SendDataForPerson();

            await communicationHubService.SendMessageForPerson("Avaible Speak Deleted");

            return new() { result = true };
        }
    }
}
