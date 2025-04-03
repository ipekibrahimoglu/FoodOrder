using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public async Task<Menu> GetByIdAsync(Guid id)
        {
            var menu = await _menuDal.GetByIdAsync(id);
            if (menu == null)
            {
                throw new Exception("Menu not found!");
            }

            return menu;
        }

        public async Task<IEnumerable<Menu>> GetAllASync()
        {
            var menus = await _menuDal.GetAllAsync();
            return menus;
        }

        public async Task<IEnumerable<Menu>> GetByConditionASync(Expression<Func<Menu, bool>> predicate)
        {
            var menus = await _menuDal.GetByConditionAsync(predicate);
            if (menus == null)
            {
                throw new Exception("There is no menu according to entered info!");
            }

            return menus;
        }

        public async Task AddAsync(Menu entity)
        {
            _menuDal.AddAsync(entity);
        }

        public async Task UpdateAsync(Menu entity)
        {
            var existingMenu = await GetByIdAsync(entity.MenuId);
            if (existingMenu == null)
            {
                throw new Exception("There is no menu to update!");
            }

            existingMenu.Name = entity.Name;
            existingMenu.Description = entity.Description;
            existingMenu.RestaurantId = entity.RestaurantId;
            _menuDal.UpdateAsync(entity); //Gecilecek parametre ne olmali bir bak.
        }

        public async Task DeleteAsync(Guid id)
        {
            var menuToDelete = await GetByIdAsync(id);
            if (menuToDelete == null)
            {
                throw new Exception("There is no menu to delete by that specified ID!");
            }

            await _menuDal.DeleteAsync(menuToDelete.MenuId); //parametrede degisiklik
        }

        public async Task<IEnumerable<MenuDto>> GetMenusByRestaurantId(Guid restaurantId)
        {
            return await _menuDal.GetMenusByRestaurantIdAsync(restaurantId);
        }
    }
}
