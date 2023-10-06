using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class CommunicationMessageReadRepository : ReadRepository<CommunicationMessage>, ICommunicationMessageReadRepository
    {
        public CommunicationMessageReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
