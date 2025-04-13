using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IRestaurantDal : IGenericRepository<Restaurant>
{
    Task<IEnumerable<RestaurantDto>> GetRestaurantsByOwnerIdAsync(Guid ownerId);
    Task<IEnumerable<RestaurantDto>> GetAllWithDetailsAsync();
}