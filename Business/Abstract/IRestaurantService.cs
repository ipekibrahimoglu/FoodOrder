using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRestaurantService
    {
        Task<Restaurant> GetByIdAsync(Guid id);
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<IEnumerable<Restaurant>> GetByConditionAsync(Expression<Func<Restaurant, bool>> predicate);
        Task AddAsync(Restaurant entity);
        Task UpdateAsync(Restaurant entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<RestaurantDto>> GetByOwnerIdAsync(Guid ownerId);
    }
}
