using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IReviewDal : IGenericRepository<Review>
{
    Task<IEnumerable<Review>> GetReviewsByRestaurantId(Guid restaurantId);
}