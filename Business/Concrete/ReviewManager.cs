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
    public class ReviewManager : IReviewService
    {
        private IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            var review = await _reviewDal.GetByIdAsync(id);
            //null mi
            return review;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            var reviews = await _reviewDal.GetAllAsync();
            // null mi
            return reviews;
        }

        public async Task<IEnumerable<Review>> GetByConditionAsync(Expression<Func<Review, bool>> predicate)
        {
            var reviews = await _reviewDal.GetByConditionAsync(predicate);
            // null mi
            return reviews;
        }

        public async Task AddAsync(Review entity)
        {
            await _reviewDal.AddAsync(entity);
        }

        public async Task UpdateAsync(Review entity)
        {
            var existingReview = await _reviewDal.GetByIdAsync(entity.ReviewId);
            // null mi
            existingReview.RestaurantId = entity.RestaurantId;
            existingReview.Rating = entity.Rating;
            existingReview.UserId = entity.UserId;
            await _reviewDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var reviewToDelete = await _reviewDal.GetByIdAsync(id);
            // null mi
            await _reviewDal.DeleteAsync(reviewToDelete.ReviewId);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByRestaurantId(Guid id)
        {
            var reviews = await _reviewDal.GetReviewsByRestaurantId(id);
            //null mi
            return reviews;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByUserId(Guid id)
        {
            return await _reviewDal.GetReviewsByUserId(id);
        }
    }
}
