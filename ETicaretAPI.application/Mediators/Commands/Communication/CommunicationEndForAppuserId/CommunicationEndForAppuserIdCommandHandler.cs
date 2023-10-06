using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Communication.CommunicationEndForAppuserId
{
    public class CommunicationEndForAppuserIdCommandHandler : IRequestHandler<CommunicationEndForAppuserIdCommandRequest, CommunicationEndForAppuserIdCommandResponse>
    {
        private readonly ICommunicationCustomerPersonWriteRepository communicationCustomerPersonWriteRepository;
        private readonly ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository;
        private readonly ICommunicationHubService communicationHubService;
        private readonly ICommunicationMessageWriteRepository communicationMessageWriteRepository;
        private readonly ICommunicationMessageReadRepository communicationMessageReadRepository;
        public CommunicationEndForAppuserIdCommandHandler(ICommunicationCustomerPersonWriteRepository communicationCustomerPersonWriteRepository, ICommunicationCustomerPersonReadRepository communicationCustomerPersonReadRepository, ICommunicationHubService communicationHubService, ICommunicationMessageWriteRepository communicationMessageWriteRepository, ICommunicationMessageReadRepository communicationMessageReadRepository)
        {
            this.communicationCustomerPersonWriteRepository = communicationCustomerPersonWriteRepository;
            this.communicationCustomerPersonReadRepository = communicationCustomerPersonReadRepository;
            this.communicationHubService = communicationHubService;
            this.communicationMessageWriteRepository = communicationMessageWriteRepository;
            this.communicationMessageReadRepository = communicationMessageReadRepository;
        }

        public async Task<CommunicationEndForAppuserIdCommandResponse> Handle(CommunicationEndForAppuserIdCommandRequest request, CancellationToken cancellationToken)
        {
            //ComunicationCustomerPerson
            Guid cPersonId = Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81");
            var cCustomerPerson = await communicationCustomerPersonReadRepository.GetAsync(cp => cp.CommunicationPersonId == cPersonId && cp.AppUserId == request.Id && cp.IsSuccess == true);

            CommunicationMessage cMessage = await communicationMessageReadRepository.GetAsync(cm => cm.CommunicationCustomerPersonId == cCustomerPerson.Id && cm.IsSuccess == true);
            if (cMessage is not null)
                communicationMessageWriteRepository.Delete(cMessage); // !

            communicationCustomerPersonWriteRepository.Delete(cCustomerPerson);

            await communicationCustomerPersonWriteRepository.SaveChangesAsync();

            await communicationHubService.SendDataForUser();
            await communicationHubService.SendDataForPerson();

            await communicationHubService.SendMessageForUser("Avaible Speak Deleted");

            return new() { result = true };
        }
    }
}
