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
    public class EfRestaurantDal : EfGenericRepository<Restaurant, SouthwindContext>, IRestaurantDal
    {
        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsByOwnerIdAsync(Guid ownerId)
        {
            using var context = new SouthwindContext();
            var restaurants = await context.Restaurants
                .Where(r => r.OwnerId == ownerId)
                .Include(r => r.Reviews)
                .Select(r => new RestaurantDto
                {
                    Address = r.Address,
                    Description = r.Description,
                    Name = r.Name,
                    OwnerId = r.OwnerId,
                    PhoneNumber = r.PhoneNumber,
                    RestaurantId = r.RestaurantId,
                    Reviews = r.Reviews.Select(rv => new ReviewDto
                    {
                        ReviewId = rv.ReviewId,
                        UserId = rv.UserId,
                        RestaurantId = rv.RestaurantId,
                        Rating = rv.Rating
                    }).ToList()
                }).ToListAsync();
            return restaurants;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();
            var result = await context.Restaurants
                .Include(r => r.Menus)
                .Include(r => r.Reviews)
                .Include(r => r.Owner)
                .Select(r => new RestaurantDto
                {
                    Address = r.Address,
                    Description = r.Description,
                    Name = r.Name,
                    OwnerId = r.OwnerId,
                    PhoneNumber = r.PhoneNumber,
                    RestaurantId = r.RestaurantId,
                    Menus = r.Menus.Select(m => new MenuDto
                    {
                        Description = m.Description,
                        MenuId = m.MenuId,
                        Name = m.Name
                    }).ToList(),
                    Reviews = r.Reviews.Select(re => new ReviewDto
                    {
                        Rating = re.Rating,
                        ReviewId = re.ReviewId,
                        UserId = re.UserId
                    }).ToList(),
                    User = new UserDto
                    {
                        Email = r.Owner.Email,
                        FullName = r.Owner.FullName,
                        PhoneNumber = r.Owner.PhoneNumber,
                        Role = r.Owner.Role,
                        UserId = r.Owner.UserId
                    }
                }).ToListAsync();
            return result;
        }
    }
}
