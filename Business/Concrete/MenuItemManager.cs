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
    public class MenuItemManager : IMenuItemService
    {
        private IMenuItemDal _menuItemDal;

        public MenuItemManager(IMenuItemDal menuItemDal)
        {
            _menuItemDal = menuItemDal;
        }

        public async Task<IDataResult<MenuItem>> GetByIdAsync(Guid id)
        {
            var item = await _menuItemDal.GetByIdAsync(id);
            if (item == null)
            {
                throw new Exception("Item not found!");
            }

            return new SuccessDataResult<MenuItem>(item);
        }

        public async Task<IDataResult<IEnumerable<MenuItemDto>>> GetAllAsync()
        {
            var items = await _menuItemDal.GetAllWithDetailsAsync();
            if (items == null)
            {
                throw new Exception("Items not found!");
            }

            return new SuccessDataResult<IEnumerable<MenuItemDto>>(items);
        }

        public async Task<IDataResult<IEnumerable<MenuItem>>> GetByConditionAsync(Expression<Func<MenuItem, bool>> predicate)
        {
            var items = await _menuItemDal.GetByConditionAsync(predicate);
            if (items == null)
            {
                throw new Exception("Item(s) not found!");
            }

            return new SuccessDataResult<IEnumerable<MenuItem>>(items);
        }

        public async Task<IResult> AddAsync(MenuItem entity)
        {
            await _menuItemDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(MenuItem entity)
        {
            var existingItem = await _menuItemDal.GetByIdAsync(entity.MenuItemId);
            if (existingItem == null)
            {
                throw new Exception("There is no item by that specific ID!");
            }

            existingItem.Name = entity.Name;
            existingItem.Description = entity.Description;
            existingItem.MenuId = entity.MenuId;
            existingItem.ImageUrl = existingItem.ImageUrl;

            await _menuItemDal.UpdateAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var itemToDelete = await _menuItemDal.GetByIdAsync(id);
            if (itemToDelete == null)
            {
                throw new Exception("No item to delete!");
            }

            await _menuItemDal.DeleteAsync(itemToDelete.MenuItemId);
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<MenuItemDto>>> GetMenuItemsByMenuIdAsync(Guid id)
        {
            return new SuccessDataResult<IEnumerable<MenuItemDto>>(await _menuItemDal.GetMenuItemsByMenuIdAsync(id));
        }
    }
}
