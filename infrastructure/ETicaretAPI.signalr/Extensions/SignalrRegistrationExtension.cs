using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.signalr.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.signalr.Extensions
{
    public static class SignalrRegistrationExtension
    {
        public static void AddSignalRServices(this IServiceCollection builder)
        {
            builder.AddTransient<IProductHubService, ProductHubService>();
            builder.AddTransient<IAuthenticationHubService, AuthenticationHubService>();
            builder.AddTransient<IConnectionHubService, ConnectionHubService>();
            builder.AddTransient<ICommunicationHubService, CommunicationHubService>();
            builder.AddTransient<IChatHubService, ChatHubService>();

            builder.AddSignalR();
        }
    }
}
