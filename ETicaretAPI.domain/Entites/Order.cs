using ETicaretAPI.domain.Entites.Base;
using System.Security.Principal;

namespace ETicaretAPI.domain.Entites
{
    public class Order : EntityBase
    {
        public string Description { get; set; }


        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }


        public Basket Basket { get; set; }


        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
