using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IOrderItemDal : IGenericRepository<OrderItem>
{
    Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(Guid orderId);
    Task<IEnumerable<OrderItemDto>> GetAllWithDetailsAsync();
}