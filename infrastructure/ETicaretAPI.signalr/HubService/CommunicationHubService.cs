using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Statics;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;
using ETicaretAPI.signalr.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ETicaretAPI.signalr.HubService
{
    public class CommunicationHubService : ICommunicationHubService
    {
        private readonly IHubContext<CommunicationHub> _hubContext;
        private readonly ETicaretAPIProjectDbContext context;
        public CommunicationHubService(IHubContext<CommunicationHub> hubContext, ETicaretAPIProjectDbContext context)
        {
            _hubContext = hubContext;
            this.context = context;
        }

        public async Task SendDataForPerson()
        {
            var cCustomerPersons = await context.Set<CommunicationCustomerPerson>()
                                   .Where(cp => cp.IsSuccess == true && cp.CommunicationPersonId == Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81"))
                                   .ToListAsync();

            await _hubContext.Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.CommunicationCustomerPersonForPerson, cCustomerPersons);
        }

        public async Task SendDataForUser()
        {
            var cCustomerPerson = await context.Set<CommunicationCustomerPerson>()
                                 .FirstOrDefaultAsync(cp => cp.IsSuccess == true && cp.AppUserId == StaticPropertiesApp.AppUserId && cp.CommunicationPersonId == Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81"));

            await _hubContext.Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.CommunicationCustomerPersonForUser, cCustomerPerson);
        }





        public async Task SendMessageForPerson(string? message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.ActiveCommunicationsForPersonMessage, message);
        }

        public async Task SendMessageForUser(string? message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.ActiveCommunicationForUserMessage, message);
        }
    }
}
