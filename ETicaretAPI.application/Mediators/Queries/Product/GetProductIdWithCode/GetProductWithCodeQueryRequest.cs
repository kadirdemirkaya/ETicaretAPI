using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductIdWithCode
{
    public class GetProductWithCodeQueryRequest : IRequest<GetProductWithCodeQueryResponse>
    {
        [FromHeader]
        public Guid ProductCode { get; set; }
    }
}
