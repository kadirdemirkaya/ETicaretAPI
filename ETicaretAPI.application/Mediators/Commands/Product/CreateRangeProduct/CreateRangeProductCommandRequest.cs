using ETicaretAPI.application.DTOs.Product;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.CreateRangeProduct
{
    public class CreateRangeProductCommandRequest : IRequest<CreateRangeProductCommandResponse>
    {
        public List<AddProductDto> AddProductDtos { get; set; }
    }
}
