using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.UnitOfWorks;

namespace ETicaretAPI.persistence.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IUnitOfWork unitOfWork;

        public CommunicationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
