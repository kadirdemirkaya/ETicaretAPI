namespace ETicaretAPI.application.DTOs.Address
{
    public class AddAddressDto
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Description { get; set; } = "NONE";
    }
}
