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
    public class RestaurantManager : IRestaurantService
    {
        private IRestaurantDal _restaurantDal;

        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }
        public async Task<IDataResult<Restaurant>> GetByIdAsync(Guid id)
        {
            var restaurant = await _restaurantDal.GetByIdAsync(id);
            // null mi kontrolleri
            return new SuccessDataResult<Restaurant>(restaurant);
        }

        public async Task<IDataResult<IEnumerable<Restaurant>>> GetAllAsync()
        {
            var restaurants = await _restaurantDal.GetAllAsync();
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<Restaurant>>(restaurants);
        }

        public async Task<IDataResult<IEnumerable<Restaurant>>> GetByConditionAsync(Expression<Func<Restaurant, bool>> predicate)
        {
            var restaurants = await _restaurantDal.GetByConditionAsync(predicate);
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<Restaurant>>(restaurants);
        }

        public async Task<IResult> AddAsync(Restaurant entity)
        {
            await _restaurantDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Restaurant entity)
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
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var restaurantToDelete = await _restaurantDal.GetByIdAsync(id);
            // null mi kontrolleri
            await _restaurantDal.DeleteAsync(restaurantToDelete.RestaurantId);
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<RestaurantDto>>> GetRestaurantsByOwnerIdAsync(Guid ownerId)
        {
            var restaurants = await _restaurantDal.GetRestaurantsByOwnerIdAsync(ownerId);
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<RestaurantDto>>(restaurants);
        }
    }
}
