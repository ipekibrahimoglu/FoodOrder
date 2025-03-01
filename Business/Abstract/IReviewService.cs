using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IReviewService
    {
        Task<Review> GetByIdAsync(Guid id);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetByConditionAsync(Expression<Func<Review, bool>> predicate);
        Task AddAsync(Review entity);
        Task UpdateAsync(Review entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Review>> GetReviewsByRestaurantId(Guid restaurantId);
    }
}
