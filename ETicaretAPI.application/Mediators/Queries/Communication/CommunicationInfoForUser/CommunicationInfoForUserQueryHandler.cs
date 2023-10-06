using AutoMapper;
using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.DTOs.Communication;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.application.Statics;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.application.Mediators.Queries.Communication.CommunicationInfoForUser
{
    public class CommunicationInfoForUserQueryHandler : IRequestHandler<CommunicationInfoForUserQueryRequest, CommunicationInfoForUserQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly IChatHubService chatHubService;
        private readonly ICommunicationMessageReadRepository communicationMessageReadRepository;
        public CommunicationInfoForUserQueryHandler(IMapper mapper, ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IChatHubService chatHubService, ICommunicationMessageReadRepository communicationMessageReadRepository)
        {
            this.mapper = mapper;
            this.communicationCustomerPersonReadRepository = communicationCustomerPersonReadRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.chatHubService = chatHubService;
            this.communicationMessageReadRepository = communicationMessageReadRepository;
        }

        public async Task<CommunicationInfoForUserQueryResponse> Handle(CommunicationInfoForUserQueryRequest request, CancellationToken cancellationToken)
        {
            string userName = httpContextAccessor.HttpContext.Request.HttpContext.User.Identity.Name;
            AppUser? appUser = await userManager.FindByNameAsync(userName);
            if (appUser is not null)
                StaticPropertiesApp.AppUserId = appUser.Id;

            Guid cPersonId = Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81");
            var cCustomerPerson = await communicationCustomerPersonReadRepository.GetAsync(cp => cp.CommunicationPersonId == cPersonId && cp.IsSuccess == true && cp.AppUserId == StaticPropertiesApp.AppUserId);

            if (cCustomerPerson is null)
                return new() { CommunicationForUserDto = null };

            var map = mapper.Map<CommunicationForUserDto?>(cCustomerPerson);

            var allMessages = await communicationMessageReadRepository.GetAllAsync(cm => cm.CommunicationCustomerPersonId == cCustomerPerson.Id && cm.IsSuccess == true);
            await chatHubService.SendMessageAsync(allMessages);

            return new() { CommunicationForUserDto = map };
        }
    }
}
