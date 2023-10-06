using ETicaretAPI.domain.Entites.Base;
using ETicaretAPI.domain.Entites.Identity;

namespace ETicaretAPI.domain.Entites
{
    public class CommunicationCustomerPerson : EntityBase
    {
        public Guid? CommunicationPersonId { get; set; } = Guid.Parse("00000882-fbf7-4ffb-951b-2887ec307d81");
        public CommunicationPerson? CommunicationPerson { get; set; }


        public AppUser AppUser { get; set; }
        public Guid? AppUserId { get; set; }

        public List<CommunicationMessage>? CommunicationMessages { get; set; }
    }
}
