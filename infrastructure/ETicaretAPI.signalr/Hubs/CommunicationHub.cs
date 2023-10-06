using ETicaretAPI.application.Statics;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.signalr.Hubs
{
    public class CommunicationHub : Hub
    {
        private readonly ETicaretAPIProjectDbContext context;

        public CommunicationHub(ETicaretAPIProjectDbContext context)
        {
            this.context = context;
        }

        public async Task SendCommunicationCustomerPersonForUser()
        {
            var cCustomerPerson = await context.Set<CommunicationCustomerPerson>()
            .FirstOrDefaultAsync(cp => cp.IsSuccess == true && cp.AppUserId == StaticPropertiesApp.AppUserId && cp.CommunicationPersonId == Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81"));

            await Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.CommunicationCustomerPersonForUser, cCustomerPerson);
        }

        public async Task SendCommunicationCustomerPersonForPerson()
        {
            var cCustomerPersons = await context.Set<CommunicationCustomerPerson>()
            .Where(cp => cp.IsSuccess == true && cp.CommunicationPersonId == Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81"))
            .ToListAsync();

            await Clients.All.SendAsync(ReceiveFuncNames.ReceiveFunctions.CommunicationCustomerPersonForPerson, cCustomerPersons);
        }
    }
}