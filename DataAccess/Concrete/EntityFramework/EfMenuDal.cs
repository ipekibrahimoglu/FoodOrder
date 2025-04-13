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
        public async Task<IEnumerable<MenuDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();

            var result = await context.Menus
                .Include(m => m.Restaurant)
                .Include(m => m.MenuItems)
                .Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    RestaurantId = m.RestaurantId,
                    Name = m.Name,
                    Description = m.Description,

                    
                    Restaurant = new RestaurantDto
                    {
                        RestaurantId = m.Restaurant.RestaurantId,
                        OwnerId = m.Restaurant.OwnerId,
                        Name = m.Restaurant.Name,
                        Description = m.Restaurant.Description,
                        Address = m.Restaurant.Address,
                        PhoneNumber = m.Restaurant.PhoneNumber
                    },

                    
                    MenuItems = m.MenuItems.Select(mi => new MenuItemDto
                    {
                        MenuItemId = mi.MenuItemId,
                        MenuId = mi.MenuId,
                        Name = mi.Name,
                        Description = mi.Description,
                        Price = mi.Price,
                        ImageUrl = mi.ImageUrl
                    }).ToList()
                })
                .ToListAsync();

            return result;
        }

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
