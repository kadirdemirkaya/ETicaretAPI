using ETicaretAPI.signalr.Hubs;
using Microsoft.AspNetCore.Builder;

namespace ETicaretAPI.signalr.Extensions
{
    public static class SignalrHubRegistrationExtension
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductsHub>("/productsInfoHub");
            webApplication.MapHub<AuthenticationHub>("/loginHub");
            webApplication.MapHub<ConnectionHub>("/connectionHub");
            webApplication.MapHub<CommunicationHub>("/communicationHub");
            webApplication.MapHub<ChatHub>("/chatHub");
        }
    }
}
