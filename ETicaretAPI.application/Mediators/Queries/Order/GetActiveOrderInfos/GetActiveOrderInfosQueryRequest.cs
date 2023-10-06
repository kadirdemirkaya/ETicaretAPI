using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Queries.Order.GetActiveOrderInfos
{
    public class GetActiveOrderInfosQueryRequest : IRequest<GetActiveOrderInfosQueryResponse>
    {
        [FromHeader]
        public Guid OrderId { get; set; }
    }
}
