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
    public class EfUserDal : EfGenericRepository<User, SouthwindContext>, IUserDal
    {
        public async Task<UserDto> GetByEmailAsync(string email)
        {
            using var context = new SouthwindContext();
            var user = await context.Users
                .Where(u => u.Email == email)
                .Select(u => new UserDto
                {
                    Email = u.Email,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    UserId = u.UserId
                })
                .SingleOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<UserDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();
            var result = await context.Users
                .Include(u => u.Reviews)
                .Include(u => u.OwnedRestaurants)
                .Select(u => new UserDto
                {
                    Email = u.Email,
                    FullName = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    Role = u.Role,
                    UserId = u.UserId,
                    Reviews = u.Reviews.Select(r => new ReviewDto
                    {
                        RestaurantId = r.RestaurantId,
                        Rating = r.Rating,
                        ReviewId = r.ReviewId
                    }).ToList(),
                    OwnedRestaurants = u.OwnedRestaurants.Select(re => new RestaurantDto
                    {
                        Address = re.Address,
                        Description = re.Description,
                        Name = re.Name,
                        PhoneNumber = re.PhoneNumber,
                        RestaurantId = re.RestaurantId,
                        Menus = re.Menus.Select(m => new MenuDto
                        {
                            Description = m.Description,
                            MenuId = m.MenuId,
                            Name = m.Name,
                            MenuItems = m.MenuItems.Select(mi => new MenuItemDto
                            {
                                Description = mi.Description,
                                ImageUrl = mi.ImageUrl,
                                MenuItemId = mi.MenuItemId,
                                Name = mi.Name,
                                Price = mi.Price
                            }).ToList()
                        }).ToList()
                    }).ToList()
                }).ToListAsync();
            return result;
        }
    }
}
