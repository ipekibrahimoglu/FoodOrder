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
    public interface IRestaurantService
    {
        Task<IDataResult<Restaurant>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<Restaurant>>> GetAllAsync();
        Task<IDataResult<IEnumerable<Restaurant>>> GetByConditionAsync(Expression<Func<Restaurant, bool>> predicate);
        Task<IResult> AddAsync(Restaurant entity);
        Task<IResult> UpdateAsync(Restaurant entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<RestaurantDto>>> GetRestaurantsByOwnerIdAsync(Guid ownerId);
    }
}
