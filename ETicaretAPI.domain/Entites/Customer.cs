using ETicaretAPI.domain.Entites.Base;
using ETicaretAPI.domain.Entites.Identity;

namespace ETicaretAPI.domain.Entites
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }


        public ICollection<Order> Orders { get; set; }

        public Guid? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
