using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IReviewDal : IGenericRepository<Review>
{
    Task<IEnumerable<ReviewDto>> GetReviewsByRestaurantId(Guid restaurantId);
    Task<IEnumerable<ReviewDto>> GetReviewsByUserId(Guid userId);
}