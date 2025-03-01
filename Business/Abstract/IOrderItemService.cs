using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        Task<OrderItem> GetByIdAsync(Guid id);
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<IEnumerable<OrderItem>> GetByConditionAsync(Expression<Func<OrderItem, bool>>predicate);
        Task AddAsync(OrderItem entity);
        Task UpdateAsync(OrderItem entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderId(Guid orderId);
    }
}
