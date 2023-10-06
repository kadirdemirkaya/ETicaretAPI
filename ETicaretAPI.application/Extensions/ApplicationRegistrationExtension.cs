using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ETicaretAPI.application.Extensions
{
    public static class ApplicationRegistrationExtension
    {
        public static void AddApplicationLayerServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddMediatR(typeof(ApplicationRegistrationExtension));
        }
    }
}
