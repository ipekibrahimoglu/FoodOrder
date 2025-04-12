using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Menu : IEntity
    {
        public Guid MenuId { get; set; }
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        // Navigation Property: Menü hangi restorana ait?
        public Restaurant Restaurant { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
