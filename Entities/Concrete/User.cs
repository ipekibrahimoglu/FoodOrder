using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Entities.Concrete
{
    
    //Database migrationini guncelle
    //tum entitylerdeki null olabilirlikleri incele
    public class User : IEntity
    {
        public Guid UserId { get; set; } // guid kullanimi
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } 

        public string PhoneNumber { get; set; }

        
        // Navigation Property: Bir kullanıcının sahip olduğu restoranlar
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Restaurant> OwnedRestaurants { get; set; }

    }
}
