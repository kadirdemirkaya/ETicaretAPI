using ETicaretAPI.application.DTOs.Order;

namespace ETicaretAPI.application.Mediators.Queries.Order.GetActiveOrderInfos
{
    public class GetActiveOrderInfosQueryResponse
    {
        public List<ActiveOrdersDto> ActiveOrdersDtos { get; set; }
    }
}
