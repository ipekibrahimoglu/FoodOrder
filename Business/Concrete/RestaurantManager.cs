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
    public class RestaurantManager : IRestaurantService
    {
        private IRestaurantDal _restaurantDal;

        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }
        public async Task<Restaurant> GetByIdAsync(Guid id)
        {
            var restaurant = await _restaurantDal.GetByIdAsync(id);
            // null mi kontrolleri
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await _restaurantDal.GetAllAsync();
            // null mi kontrolleri
            return restaurants;
        }

        public async Task<IEnumerable<Restaurant>> GetByConditionAsync(Expression<Func<Restaurant, bool>> predicate)
        {
            var restaurants = await _restaurantDal.GetByConditionAsync(predicate);
            // null mi kontrolleri
            return restaurants;
        }

        public async Task AddAsync(Restaurant entity)
        {
            await _restaurantDal.AddAsync(entity);
        }

        public async Task UpdateAsync(Restaurant entity)
        {
            var existingRestaurant = await _restaurantDal.GetByIdAsync(entity.RestaurantId);
            // null mi kontrolleri
            existingRestaurant.Address = entity.Address;
            existingRestaurant.Description = entity.Description;
            existingRestaurant.Menus = entity.Menus;
            existingRestaurant.Name = entity.Name;
            existingRestaurant.Owner = entity.Owner;
            existingRestaurant.PhoneNumber = entity.PhoneNumber;
            await _restaurantDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var restaurantToDelete = await _restaurantDal.GetByIdAsync(id);
            // null mi kontrolleri
            await _restaurantDal.DeleteAsync(restaurantToDelete.RestaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetByOwnerIdAsync(Guid ownerId)
        {
            var restaurants = await _restaurantDal.GetByOwnerIdAsync(ownerId);
            // null mi kontrolleri
            return restaurants;
        }
    }
}
