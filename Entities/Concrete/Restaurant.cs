using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;


namespace Entities.Concrete
{
    public class Restaurant : IEntity
    {
        public Guid RestaurantId { get; set; }
        public Guid OwnerId { get; set; } //User ile iliskilendirme
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }

        // Navigation Property: Restoran sahibini temsil eder
        public User Owner { get; set; }

        // Navigation Property: Restorana ait menüler
        public ICollection<Review> Reviews { get; set; } = new List<Review>(); // nulldan korumak icin 
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();

    }
}
