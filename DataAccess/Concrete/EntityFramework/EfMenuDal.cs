using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMenuDal : EfGenericRepository<Menu, SouthwindContext>, IMenuDal
    {
        public async Task<IEnumerable<MenuDto>> GetMenusByRestaurantIdAsync(Guid restaurantId)
        {
            using var context = new SouthwindContext();
            var menus = await context.Menus
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => new MenuDto
                {
                        Description = m.Description,
                        MenuId = m.MenuId,
                        Name = m.Name,
                        RestaurantId = m.RestaurantId
                }).ToListAsync();
            return menus;
        }
    }
}
