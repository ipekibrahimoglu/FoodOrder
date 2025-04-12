using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;    // MenuDto burada tanımlı olduğunu varsayıyoruz

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryMenuDal : IMenuDal
    {
        private readonly List<Menu> _menus;

        public InMemoryMenuDal()
        {
            _menus = new List<Menu>()
            {
                new Menu
                {
                    MenuId = Guid.NewGuid(),
                    Name = "Pizza",
                    Description = "Delicious cheese pizza",
                    RestaurantId = Guid.NewGuid()
                },
                new Menu
                {
                    MenuId = Guid.NewGuid(),
                    Name = "Burger",
                    Description = "Juicy beef burger",
                    RestaurantId = Guid.NewGuid()
                }
            };
        }

        public Task<Menu> GetByIdAsync(Guid id)
        {
            var menu = _menus.SingleOrDefault(m => m.MenuId == id);
            return Task.FromResult(menu);
        }

        public Task<IEnumerable<Menu>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Menu>>(_menus);
        }

        public Task<IEnumerable<Menu>> GetByConditionAsync(Expression<Func<Menu, bool>> predicate)
        {
            var result = _menus.AsQueryable()
                               .Where(predicate)
                               .ToList();
            return Task.FromResult<IEnumerable<Menu>>(result);
        }

        public Task AddAsync(Menu entity)
        {
            _menus.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Menu entity)
        {
            var existing = _menus.SingleOrDefault(m => m.MenuId == entity.MenuId);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Description = entity.Description;
                existing.RestaurantId = entity.RestaurantId;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var toDelete = _menus.SingleOrDefault(m => m.MenuId == id);
            if (toDelete != null)
                _menus.Remove(toDelete);
            return Task.CompletedTask;
        }

        // IMenuDal'ın bu metodu Task<IEnumerable<MenuDto>> dönmeli:
        public Task<IEnumerable<MenuDto>> GetMenusByRestaurantIdAsync(Guid restaurantId)
        {
            var dtos = _menus
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    Name = m.Name,
                    Description = m.Description,
                    RestaurantId = m.RestaurantId
                })
                .ToList();

            return Task.FromResult<IEnumerable<MenuDto>>(dtos);
        }
    }
}
