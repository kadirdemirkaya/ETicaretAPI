using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.signalr.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ETicaretAPIProjectDbContext context;

        public ChatHub(ETicaretAPIProjectDbContext context)
        {
            this.context = context;
        }

        //public async Task SendMessage(Guid cCustomerPersonId)
        //{
        //    List<CommunicationMessage> message = await context.Set<CommunicationMessage>().Where(cm => cm.CommunicationCustomerPersonId == cCustomerPersonId && cm.IsSuccess == true).ToListAsync();
        //    await Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.ReceiveChatMessage, message);
        //}
    }
}
