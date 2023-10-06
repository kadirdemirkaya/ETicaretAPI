using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductByGuid
{
    public class GetProductByGuidQueryRequest : IRequest<GetProductByGuidQueryResponse>
    {
        [FromHeader]
        public Guid Id { get; set; }
    }
}
