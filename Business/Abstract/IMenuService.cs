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
    public interface IMenuService
    {
        
        Task<IDataResult<Menu>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<MenuDto>>> GetAllASync();
        Task<IDataResult<IEnumerable<Menu>>> GetByConditionASync(Expression<Func<Menu, bool>> predicate);
        Task<IResult> AddAsync(Menu entity);
        Task<IResult> UpdateAsync(Menu entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<MenuDto>>> GetMenusByRestaurantId(Guid restaurantId);
    }
}
