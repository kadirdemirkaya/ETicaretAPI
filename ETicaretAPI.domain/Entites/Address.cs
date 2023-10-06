using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.domain.Entites
{
    public class Address : EntityBase
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Description { get; set; }

        public Order Order { get; set; }
    }
}
