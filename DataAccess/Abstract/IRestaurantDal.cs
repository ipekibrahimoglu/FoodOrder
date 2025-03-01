using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IRestaurantDal : IGenericRepository<Restaurant>
{
    Task<IEnumerable<Restaurant>> GetByOwnerIdAsync(Guid ownerId);
}