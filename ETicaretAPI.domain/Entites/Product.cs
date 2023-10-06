using ETicaretAPI.domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.domain.Entites
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string ProductCode { get; set; }

        [NotMapped]
        public int? Quantity { get; set; }


        public ICollection<BasketItem>? BasketItems { get; set; }

        public virtual ICollection<ImageProduct> ImageProducts { get; set; }


        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
