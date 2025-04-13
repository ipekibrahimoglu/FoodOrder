using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IMenuItemDal : IGenericRepository<MenuItem>
    {
        Task<IEnumerable<MenuItemDto>> GetMenuItemsByMenuIdAsync(Guid menuId);
        Task<IEnumerable<MenuItemDto>> GetAllWithDetailsAsync();
    }
}
