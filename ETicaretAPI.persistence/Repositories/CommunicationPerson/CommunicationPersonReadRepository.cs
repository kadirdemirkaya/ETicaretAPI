using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class CommunicationPersonReadRepository : ReadRepository<CommunicationPerson>, ICommunicationPersonReadRepository
    {
        public CommunicationPersonReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
