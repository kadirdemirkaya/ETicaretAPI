using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.domain.Entites
{
    public class Category : EntityBase
    {
        public string Name { get; set; }


        public List<Product> Products { get; set; }
    }
}
