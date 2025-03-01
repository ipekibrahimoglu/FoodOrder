using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMenuService
    {
        //Core katmanina koyulacak Repositoryi yaz.
        Task<Menu> GetByIdAsync(Guid id);
        Task<IEnumerable<Menu>> GetAllASync();
        Task<IEnumerable<Menu>> GetByConditionASync(Expression<Func<Menu, bool>> predicate);
        Task AddAsync(Menu entity);
        Task UpdateAsync(Menu entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Menu>> GetMenusByRestaurantId(Guid restaurantId);
    }
}
