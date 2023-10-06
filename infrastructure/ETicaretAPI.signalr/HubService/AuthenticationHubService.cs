using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.signalr.Hubs;
using ETicaretAPI.signalr.ReceiveFuncNames;
using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.signalr.HubService
{
    public class AuthenticationHubService : IAuthenticationHubService
    {
        private readonly IHubContext<AuthenticationHub> _hubContext;

        public AuthenticationHubService(IHubContext<AuthenticationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task LoginMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctions.LoginMessage, message);
        }
    }
}
