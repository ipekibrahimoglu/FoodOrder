using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
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

        public async Task<IDataResult<Menu>> GetByIdAsync(Guid id)
        {
            var menu = await _menuDal.GetByIdAsync(id);
            if (menu == null)
            {
                throw new Exception("Menu not found!");
            }

            return new SuccessDataResult<Menu>(menu);
        }

        public async Task<IDataResult<IEnumerable<Menu>>> GetAllASync()
        {
            var menus = await _menuDal.GetAllAsync();
            return new SuccessDataResult<IEnumerable<Menu>>(menus);
        }

        public async Task<IDataResult<IEnumerable<Menu>>> GetByConditionASync(Expression<Func<Menu, bool>> predicate)
        {
            var menus = await _menuDal.GetByConditionAsync(predicate);
            if (menus == null)
            {
                throw new Exception("There is no menu according to entered info!");
            }

            return new SuccessDataResult<IEnumerable<Menu>>(menus);
        }

        public async Task<IResult> AddAsync(Menu entity)
        {
            _menuDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Menu entity)
        {
            var existingMenu = await _menuDal.GetByIdAsync(entity.MenuId);
            if (existingMenu == null)
            {
                throw new Exception("There is no menu to update!");
            }

            existingMenu.Name = entity.Name;
            existingMenu.Description = entity.Description;
            existingMenu.RestaurantId = entity.RestaurantId;
            _menuDal.UpdateAsync(entity); //Gecilecek parametre ne olmali bir bak.
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var menuToDelete = await _menuDal.GetByIdAsync(id);
            if (menuToDelete == null)
            {
                throw new Exception("There is no menu to delete by that specified ID!");
            }

            await _menuDal.DeleteAsync(menuToDelete.MenuId); //parametrede degisiklik
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<MenuDto>>> GetMenusByRestaurantId(Guid restaurantId)
        {
            return new SuccessDataResult<IEnumerable<MenuDto>>(await _menuDal.GetMenusByRestaurantIdAsync(restaurantId));
        }
    }
}
