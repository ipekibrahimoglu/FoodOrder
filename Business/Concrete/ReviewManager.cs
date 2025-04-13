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
    public class ReviewManager : IReviewService
    {
        private IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public async Task<IDataResult<Review>> GetByIdAsync(Guid id)
        {
            var review = await _reviewDal.GetByIdAsync(id);
            //null mi
            return new SuccessDataResult<Review>(review);
        }

        public async Task<IDataResult<IEnumerable<ReviewDto>>> GetAllAsync()
        {
            var reviews = await _reviewDal.GetAllWithDetailsAsync();
            // null mi
            return new SuccessDataResult<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<IDataResult<IEnumerable<Review>>> GetByConditionAsync(Expression<Func<Review, bool>> predicate)
        {
            var reviews = await _reviewDal.GetByConditionAsync(predicate);
            // null mi
            return new SuccessDataResult<IEnumerable<Review>>(reviews);
        }

        public async Task<IResult> AddAsync(Review entity)
        {
            await _reviewDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Review entity)
        {
            var existingReview = await _reviewDal.GetByIdAsync(entity.ReviewId);
            // null mi
            existingReview.RestaurantId = entity.RestaurantId;
            existingReview.Rating = entity.Rating;
            existingReview.UserId = entity.UserId;
            await _reviewDal.UpdateAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var reviewToDelete = await _reviewDal.GetByIdAsync(id);
            // null mi
            await _reviewDal.DeleteAsync(reviewToDelete.ReviewId);
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<ReviewDto>>> GetReviewsByRestaurantId(Guid id)
        {
            var reviews = await _reviewDal.GetReviewsByRestaurantId(id);
            //null mi
            return new SuccessDataResult<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<IDataResult<IEnumerable<ReviewDto>>> GetReviewsByUserId(Guid id)
        {
            return new SuccessDataResult<IEnumerable<ReviewDto>>(await _reviewDal.GetReviewsByUserId(id));
        }
    }
}
