using AutoMapper;
using ETicaretAPI.application.DTOs.Communication;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.application.Mediators.Queries.Communication.CommunicationInfoForCommunicationPerson
{
    public class CommunicationInfoForCommunicationPersonQueryHandler : IRequestHandler<CommunicationInfoForCommunicationPersonQueryRequest, CommunicationInfoForCommunicationPersonQueryResponse>
    {
        private readonly ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        public CommunicationInfoForCommunicationPersonQueryHandler(ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            this.communicationCustomerPersonReadRepository = communicationCustomerPersonReadRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<CommunicationInfoForCommunicationPersonQueryResponse> Handle(CommunicationInfoForCommunicationPersonQueryRequest request, CancellationToken cancellationToken)
        {
            Guid cPersonId = Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81");

            var cCustomerPersons = await communicationCustomerPersonReadRepository.GetAllAsync(cp => cp.CommunicationPersonId == cPersonId && cp.IsSuccess == true);

            if (cCustomerPersons is null)
                return new() { CommunicationForPersonDtos = null };

            var map = mapper.Map<List<CommunicationForPersonDto?>>(cCustomerPersons);

            return new() { CommunicationForPersonDtos = map };
        }
    }
}
