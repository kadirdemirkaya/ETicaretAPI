using ETicaretAPI.domain.Entites.Base;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.domain.Entites.Identity
{
    public class AppUserLogin : IdentityUserLogin<Guid>, IEntityBase
    {
    }
}
