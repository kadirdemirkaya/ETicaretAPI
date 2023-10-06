using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Identity;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class AppUserReadRepository : ReadRepository<AppUser>, IAppUserReadRepository
    {
        public AppUserReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
