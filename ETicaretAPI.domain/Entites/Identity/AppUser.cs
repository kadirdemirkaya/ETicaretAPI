using ETicaretAPI.domain.Entites.Base;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.domain.Entites.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsSuccess { get; set; }


        public ICollection<Customer> Customers { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }


        public List<CommunicationPerson> CommunicationPersons { get; set; }
        public List<CommunicationCustomerPerson> CommunicationCustomerPersons { get; set; }

    }
}
