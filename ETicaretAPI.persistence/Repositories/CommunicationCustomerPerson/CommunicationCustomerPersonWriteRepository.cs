using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class CommunicationCustomerPersonWriteRepository : WriteRepository<CommunicationCustomerPerson>, ICommunicationCustomerPersonWriteRepository
    {
        public CommunicationCustomerPersonWriteRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
