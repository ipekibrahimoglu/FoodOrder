using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MenuItemManager : IMenuItemService
    {
        private IMenuItemDal _menuItemDal;

        public MenuItemManager(IMenuItemDal menuItemDal)
        {
            _menuItemDal = menuItemDal;
        }

        public async Task<MenuItem> GetByIdAsync(Guid id)
        {
            var item = await _menuItemDal.GetByIdAsync(id);
            if (item == null)
            {
                throw new Exception("Item not found!");
            }

            return item;
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            var items = await _menuItemDal.GetAllAsync();
            if (items == null)
            {
                throw new Exception("Items not found!");
            }

            return items;
        }

        public async Task<IEnumerable<MenuItem>> GetByConditionAsync(Expression<Func<MenuItem, bool>> predicate)
        {
            var items = await _menuItemDal.GetByConditionAsync(predicate);
            if (items == null)
            {
                throw new Exception("Item(s) not found!");
            }

            return items;
        }

        public async Task AddAsync(MenuItem entity)
        {
            await _menuItemDal.AddAsync(entity);
        }

        public async Task UpdateAsync(MenuItem entity)
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
        }

        public async Task DeleteAsync(Guid id)
        {
            var itemToDelete = await _menuItemDal.GetByIdAsync(id);
            if (itemToDelete == null)
            {
                throw new Exception("No item to delete!");
            }

            await _menuItemDal.DeleteAsync(itemToDelete.MenuItemId);
        }
    }
}
