using ETicaretAPI.domain.Entites.Identity;
using ETicaretAPI.persistence.SeedDatas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.persistence.Extensions
{
    public static class PersistenceRegistrationAppExtension
    {
        public static void PersistenceApp(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            RoleSeedDatas.RoleSeedData(roleManager);
        }
    }
}
