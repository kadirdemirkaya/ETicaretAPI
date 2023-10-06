using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductImageByProductId
{
    public class GetProductImageByProductIdRequest : IRequest<GetProductImageByProductIdResponse>
    {
        [FromHeader]
        public Guid ProductId { get; set; }
    }
}
