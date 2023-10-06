using ETicaretAPI.application.DTOs.Product;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public AddProductDto AddProductDto { get; set; }
    }
}
