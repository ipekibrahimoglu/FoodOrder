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
    public interface IMenuItemService
    {
        Task<IDataResult<MenuItem>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<MenuItem>>> GetAllAsync();
        Task<IDataResult<IEnumerable<MenuItem>>> GetByConditionAsync(Expression<Func<MenuItem, bool>> predicate);
        Task<IResult> AddAsync(MenuItem entity);
        Task<IResult> UpdateAsync(MenuItem entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<MenuItemDto>>> GetMenuItemsByMenuIdAsync(Guid id);
    }
}
