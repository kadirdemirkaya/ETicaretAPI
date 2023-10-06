using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.signalr.Hubs;
using ETicaretAPI.signalr.ReceiveFuncNames;
using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.signalr.HubService
{
    public class ProductHubService : IProductHubService
    {
        private readonly IHubContext<ProductsHub> _hubContext;

        public ProductHubService(IHubContext<ProductsHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctions.ProductAddedMessage, message);
        }
    }
}
