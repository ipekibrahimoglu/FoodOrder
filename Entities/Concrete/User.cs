using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public Guid UserId { get; set; } // guid kullanimi
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } //enum kullanarak yaz core katmanini entegre ettiginde (enum: Admin, Customer, RestaurantOwner)

        public string PhoneNumber { get; set; }

        
        // Navigation Property: Bir kullanıcının sahip olduğu restoranlar
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Restaurant> OwnedRestaurants { get; set; }

    }
}
