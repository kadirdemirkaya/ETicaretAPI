using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Commands.Product.DeleteProductImageByProductId
{
    public class DeleteProductImageByProductIdRequest : IRequest<DeleteProductImageByProductIdResponse>
    {
        [FromHeader]
        public Guid ProductId { get; set; }
    }
}
