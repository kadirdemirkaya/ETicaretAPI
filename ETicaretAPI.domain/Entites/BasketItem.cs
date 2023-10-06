using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.domain.Entites
{
    public class BasketItem : EntityBase
    {
        public Guid? BasketId { get; set; }
        public Guid? ProductId { get; set; }

        public int Quantity { get; set; } = 1;

        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
