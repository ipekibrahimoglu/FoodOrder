using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfReviewDal : EfGenericRepository<Review, SouthwindContext>, IReviewDal
    {
        public async Task<IEnumerable<Review>> GetReviewsByRestaurantId(Guid restaurantId)
        {
            using var context = new SouthwindContext();
            var reviews = await context.Reviews.Where(r => r.RestaurantId == restaurantId).ToListAsync();
            return reviews;
        }
    }
}
