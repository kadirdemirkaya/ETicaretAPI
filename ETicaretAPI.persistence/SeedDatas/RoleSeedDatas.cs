using ETicaretAPI.domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.persistence.SeedDatas
{
    public class RoleSeedDatas
    {
        public static void RoleSeedData(RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>
            {
                new AppRole {Name = Statics.StaticsProperties.RoleNames.CommunicationPerson},
                new AppRole {Name = Statics.StaticsProperties.RoleNames.User},
                new AppRole {Name = Statics.StaticsProperties.RoleNames.Moderator},
                new AppRole {Name = Statics.StaticsProperties.RoleNames.Admin}
            };

            foreach (var role in roles)
            {
                var existingRole = roleManager.FindByNameAsync(role.Name).Result;
                if (existingRole is null)
                    roleManager.CreateAsync(role);
            }
        }
    }
}
