using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class CommunicationPersonWriteRepository : WriteRepository<CommunicationPerson>, ICommunicationPersonWriteRepository
    {
        public CommunicationPersonWriteRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
