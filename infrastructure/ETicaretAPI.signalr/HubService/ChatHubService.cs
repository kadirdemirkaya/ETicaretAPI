using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.signalr.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.signalr.HubService
{
    public class ChatHubService : IChatHubService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatHubService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(List<CommunicationMessage> message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.ReceiveChatMessage, message);
        }
    }
}
