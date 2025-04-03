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
