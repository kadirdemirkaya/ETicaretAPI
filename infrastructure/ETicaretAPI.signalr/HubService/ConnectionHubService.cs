using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.signalr.Hubs;
using ETicaretAPI.signalr.ReceiveFuncNames;
using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.signalr.HubService
{
    public class ConnectionHubService : IConnectionHubService
    {
        private readonly IHubContext<ConnectionHub> _hubContext;

        public ConnectionHubService(IHubContext<ConnectionHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task ConnectionMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctions.ConnectionMessage, message);
        }
    }
}
