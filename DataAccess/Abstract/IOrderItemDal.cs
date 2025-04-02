using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IOrderItemDal : IGenericRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId);
}