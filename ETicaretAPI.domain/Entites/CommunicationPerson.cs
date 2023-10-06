using ETicaretAPI.domain.Entites.Base;
using ETicaretAPI.domain.Entites.Identity;

namespace ETicaretAPI.domain.Entites
{
    public class CommunicationPerson : EntityBase
    {
        public AppUser AppUser { get; set; }
        public Guid? AppUserId { get; set; }


        public List<CommunicationCustomerPerson> communicationCustomerPersons { get; set; }
    }
}