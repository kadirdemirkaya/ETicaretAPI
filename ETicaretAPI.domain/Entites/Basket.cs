using ETicaretAPI.domain.Entites.Base;

namespace ETicaretAPI.domain.Entites
{
    public class Basket : EntityBase
    {
        public Guid UserId { get; set; }
        public bool isBasketConfirm { get; set; } = false;


        public Guid? OrderId { get; set; }
        public Order Order { get; set; }

        public ICollection<BasketItem>? BasketItems { get; set; }
    }
}
