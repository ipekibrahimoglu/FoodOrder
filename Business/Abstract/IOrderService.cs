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
    public interface IOrderService
    {
        Task<IDataResult<Order>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<Order>>> GetAllAsync();
        Task<IDataResult<IEnumerable<Order>>> GetByConditionAsync(Expression<Func<Order, bool>> predicate);
        Task<IResult> AddAsync(Order entity);
        Task<IResult> UpdateAsync(Order entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(Guid userId);
        Task<IDataResult<IEnumerable<OrderDto>>> GetOrdersByRestaurantIdAsync(Guid id);
    }
}
