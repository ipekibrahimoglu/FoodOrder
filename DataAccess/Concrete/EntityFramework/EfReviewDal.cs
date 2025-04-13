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
    public class EfReviewDal : EfGenericRepository<Review, SouthwindContext>, IReviewDal
    {
        public async Task<IEnumerable<ReviewDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();
            var result =  await context.Reviews
                .Include(r => r.User)
                .Include(r => r.Restaurant)
                .Select(r => new ReviewDto
                {
                    ReviewId = r.ReviewId,
                    UserId = r.UserId,
                    RestaurantId = r.RestaurantId,
                    Rating = r.Rating,

                    User = new UserDto
                    {
                        UserId = r.User.UserId,
                        FullName = r.User.FullName,
                        Email = r.User.Email,
                        Role = r.User.Role,
                        PhoneNumber = r.User.PhoneNumber
                    },

                    Restaurant = new RestaurantDto
                    {
                        RestaurantId = r.Restaurant.RestaurantId,
                        OwnerId = r.Restaurant.OwnerId,
                        Name = r.Restaurant.Name,
                        Description = r.Restaurant.Description,
                        Address = r.Restaurant.Address,
                        PhoneNumber = r.Restaurant.PhoneNumber
                    }
                })
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByRestaurantId(Guid restaurantId)
        {
            using var context = new SouthwindContext();
            var reviews = await context.Reviews
                .Where(r => r.RestaurantId == restaurantId)
                .Select(r => new ReviewDto
                {
                    Rating = r.Rating,
                    RestaurantId = r.RestaurantId,
                    ReviewId = r.ReviewId,
                    UserId = r.UserId
                }).ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByUserId(Guid userId)
        {
            using var context = new SouthwindContext();
            var reviews = await context.Reviews
                .Where(r => r.UserId == userId)
                .Select(r => new ReviewDto
                {
                    ReviewId = r.ReviewId,
                    UserId = r.UserId,
                    Rating = r.Rating,
                    RestaurantId = r.RestaurantId
                }).ToListAsync();
            return reviews;
        }
    }
}
