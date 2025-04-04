using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IReviewService
    {
        Task<IDataResult<Review>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<Review>>> GetAllAsync();
        Task<IDataResult<IEnumerable<Review>>> GetByConditionAsync(Expression<Func<Review, bool>> predicate);
        Task<IResult> AddAsync(Review entity);
        Task<IResult> UpdateAsync(Review entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<IEnumerable<ReviewDto>>> GetReviewsByRestaurantId(Guid id);
        Task<IDataResult<IEnumerable<ReviewDto>>> GetReviewsByUserId(Guid id);
    }
}
