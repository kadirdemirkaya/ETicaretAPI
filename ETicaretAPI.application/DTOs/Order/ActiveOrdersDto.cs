namespace ETicaretAPI.application.DTOs.Order
{
    public class ActiveOrdersDto
    {
        public Guid? UserId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? BasketId { get; set; }
        public int BasketItemQuantity { get; set; }
        public int ProductStock { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public double ProductPrice { get; set; }

    }
}
