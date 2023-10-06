using ETicaretAPI.application.DTOs.Product;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductImageByProductId
{
    public class GetProductImageByProductIdResponse
    {
        public List<string> Paths { get; set; }
    }
}
