using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class CommunicationMessageWriteRepository : WriteRepository<CommunicationMessage>, ICommunicationMessageWriteRepository
    {
        public CommunicationMessageWriteRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
