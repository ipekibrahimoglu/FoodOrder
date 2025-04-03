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
    public class EfRestaurantDal : EfGenericRepository<Restaurant, SouthwindContext>, IRestaurantDal
    {
        public async Task<IEnumerable<RestaurantDto>> GetByOwnerIdAsync(Guid ownerId)
        {
            using var context = new SouthwindContext();
            var restaurants = await context.Restaurants
                .Where(r => r.OwnerId == ownerId)
                .Select(r => new RestaurantDto
                {
                    Address = r.Address,
                    Description = r.Description,
                    Name = r.Name,
                    OwnerId = r.OwnerId,
                    PhoneNumber = r.PhoneNumber,
                    RestaurantId = r.RestaurantId
                }).ToListAsync();
            return restaurants;
        }
    }
}
