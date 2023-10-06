using ETicaretAPI.application.DTOs.Address;
using ETicaretAPI.application.DTOs.Order;
using ETicaretAPI.domain.Entites;

namespace ETicaretAPI.application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<Guid> AddOrderWithRelations(AddOrderDto addOrderDto, AddAddressDto addAddressDto);

        Task<List<ActiveOrdersDto>> GetUserActiveOrders(Guid userId,Guid orderId);

        Task<bool> CancelToOrder(Guid orderId);

        Task<List<Order>> GetActiveOrNotActiveOrdersAsync(bool isSuccessOrder);
    }
}
