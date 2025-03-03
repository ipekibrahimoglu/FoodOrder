using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryMenuDal : IMenuDal
    {
        private List<Menu> _menus;

        public InMemoryMenuDal()
        {
            _menus = new List<Menu>()
            {
                new Menu
                {
                    MenuId = Guid.NewGuid(), Name = "Pizza", Description = "Delicious cheese pizza",
                    RestaurantId = Guid.NewGuid()
                },
                new Menu
                {
                    MenuId = Guid.NewGuid(), Name = "Burger", Description = "Juicy beef burger",
                    RestaurantId = Guid.NewGuid()
                }
            };
        }
        public async Task<Menu> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _menus.AsQueryable().SingleOrDefaultAsync(m => m.MenuId == id)); // linq sorgusu, FirstOrDefault() kullanilabilir
        }

        public async Task<IEnumerable<Menu>> GetAllAsync()
        {
            return await Task.Run(() => _menus);
        }

        public async Task<IEnumerable<Menu>> GetByConditionAsync(Expression<Func<Menu, bool>> predicate)
        {
            return await Task.Run(() => _menus.AsQueryable().Where(predicate).ToListAsync());
        }

        public async Task AddAsync(Menu entity)
        {
            await Task.Run(() => _menus.Add(entity)).ConfigureAwait(false);
        }

        public async Task UpdateAsync(Menu entity)
        {
            var existingMenu = await GetByIdAsync(entity.MenuId);
            if (existingMenu != null)
            {
                existingMenu.Name = entity.Name;
                existingMenu.Description = entity.Description;
                existingMenu.RestaurantId = entity.RestaurantId;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var menuToDelete = await GetByIdAsync(id);
            if (menuToDelete != null)
            {
                _menus.Remove(menuToDelete);
            }
        }

        public async Task<IEnumerable<Menu>> GetMenusByRestaurantIdAsync(Guid restaurantId)
        {
            return await Task.Run(() => _menus.AsQueryable().Where(m => m.RestaurantId == restaurantId).ToListAsync()); // AsQueryable() ile veritabani sorgusu yapildi.
        }
    }
}
