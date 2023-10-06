using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites.Identity;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class AppUserWriteRepository : WriteRepository<AppUser>, IAppUserWriteRepository
    {
        public AppUserWriteRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
