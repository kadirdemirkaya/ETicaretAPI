namespace ETicaretAPI.application.DTOs.Product
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public string ProductCode { get; set; } = Guid.NewGuid().ToString();
    }
}
