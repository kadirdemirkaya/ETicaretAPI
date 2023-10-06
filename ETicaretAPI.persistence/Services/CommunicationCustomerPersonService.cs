using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.UnitOfWorks;

namespace ETicaretAPI.persistence.Services
{
    public class CommunicationCustomerPersonService : ICommunicationCustomerPersonService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommunicationCustomerPersonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
