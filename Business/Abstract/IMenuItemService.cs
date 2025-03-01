using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMenuItemService
    {
        Task<MenuItem> GetByIdAsync(Guid id);
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<IEnumerable<MenuItem>> GetByConditionAsync(Expression<Func<MenuItem, bool>> predicate);
        Task AddAsync(MenuItem entity);
        Task UpdateAsync(MenuItem entity);
        Task DeleteAsync(Guid id);
    }
}
