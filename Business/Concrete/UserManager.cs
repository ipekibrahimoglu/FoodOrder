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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _userDal.GetByIdAsync(id);
            // null mi
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _userDal.GetAllAsync();
            // null mi
            return users;
        }

        public async Task<IEnumerable<User>> GetByConditionAsync(Expression<Func<User, bool>> predicate)
        {
            var users = await _userDal.GetByConditionAsync(predicate);
            // null mi
            return users;
        }

        public async Task AddAsync(User entity)
        {
            await _userDal.AddAsync(entity);
        }

        public async Task UpdateAsync(User entity)
        {
            var existingUser = await _userDal.GetByIdAsync(entity.UserId);
            // null mi
            existingUser.Email = entity.Email;
            existingUser.FullName = entity.FullName;
            existingUser.OwnedRestaurants = entity.OwnedRestaurants; // burayi nasil yonetecegini coz
            existingUser.PhoneNumber = entity.PhoneNumber;
            existingUser.Role = entity.Role;
            await _userDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var userToDelete = await _userDal.GetByIdAsync(id);
            // null mi
            await _userDal.DeleteAsync(userToDelete.UserId);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _userDal.GetByEmailAsync(email);
            // null mi
            return user;
        }
        }
    }

