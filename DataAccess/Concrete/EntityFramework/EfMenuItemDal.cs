using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMenuItemDal : EfGenericRepository<MenuItem, SouthwindContext>, IMenuItemDal
    {
        public async Task<IEnumerable<MenuItemDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();
            var result = await context.MenuItems
                .Select(mi => new MenuItemDto
                {
                    Description = mi.Description,
                    ImageUrl = mi.ImageUrl,
                    MenuId = mi.MenuId,
                    MenuItemId = mi.MenuItemId,
                    Name = mi.Name,
                    Price = mi.Price
                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<MenuItemDto>> GetMenuItemsByMenuIdAsync(Guid menuId)
        {
            using var context = new SouthwindContext();
            var menuItems = await context.MenuItems
                .Where(mi => mi.MenuId == menuId)
                .Select(mi => new MenuItemDto
                {
                    Description = mi.Description,
                    ImageUrl = mi.ImageUrl,
                    MenuId = mi.MenuId,
                    MenuItemId = mi.MenuItemId,
                    Name = mi.Name,
                    Price = mi.Price
                }).ToListAsync();
            return menuItems;
        }
    }
}
