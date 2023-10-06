using ETicaretAPI.application.Repositories;
using ETicaretAPI.domain.Entites;
using ETicaretAPI.persistence.Data;

namespace ETicaretAPI.persistence.Repositories
{
    public class CommunicationCustomerPersonReadRepository : ReadRepository<CommunicationCustomerPerson>, ICommunicationCustomerPersonReadRepository
    {
        public CommunicationCustomerPersonReadRepository(ETicaretAPIProjectDbContext context) : base(context)
        {
        }
    }
}
