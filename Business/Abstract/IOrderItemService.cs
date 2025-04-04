using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        Task<IDataResult<OrderItem>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<OrderItem>>> GetAllAsync();
        Task<IDataResult<IEnumerable<OrderItem>>> GetByConditionAsync(Expression<Func<OrderItem, bool>>predicate);
        Task<IResult> AddAsync(OrderItem entity);
        Task<IResult> UpdateAsync(OrderItem entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<OrderItemDto>>> GetOrderItemsByOrderId(Guid orderId);
    }
}
