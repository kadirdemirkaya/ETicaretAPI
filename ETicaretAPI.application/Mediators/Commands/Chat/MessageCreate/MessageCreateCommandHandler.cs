using AutoMapper;
using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Chat.MessageCreate
{
    public class MessageCreateCommandHandler : IRequestHandler<MessageCreateCommandRequest, MessageCreateCommandResponse>
    {
        private readonly ICommunicationMessageWriteRepository communicationMessageWriteRepository;
        private readonly ICommunicationMessageReadRepository communicationMessageReadRepository;
        private readonly IMapper mapper;
        private readonly IChatHubService chatHubService;
        public MessageCreateCommandHandler(ICommunicationMessageWriteRepository communicationMessageWriteRepository, IMapper mapper, IChatHubService chatHubService, ICommunicationMessageReadRepository communicationMessageReadRepository)
        {
            this.communicationMessageWriteRepository = communicationMessageWriteRepository;
            this.mapper = mapper;
            this.chatHubService = chatHubService;
            this.communicationMessageReadRepository = communicationMessageReadRepository;
        }

        public async Task<MessageCreateCommandResponse> Handle(MessageCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<CommunicationMessage>(request.MessageDto);
            await communicationMessageWriteRepository.AddAsync(map);
            await communicationMessageWriteRepository.SaveChangesAsync();

            var allMessages = await communicationMessageReadRepository.GetAllAsync(cm => cm.CommunicationCustomerPersonId == request.MessageDto.CommunicationCustomerPersonId && cm.IsSuccess == true);
            await chatHubService.SendMessageAsync(allMessages);

            return new() { result = true };
        }
    }
}
