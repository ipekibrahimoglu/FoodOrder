using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class MenuDto: IDto
    {
        public Guid MenuId { get; set; }
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RestaurantDto? Restaurant { get; set; }
        public IEnumerable<MenuItemDto>? MenuItems { get; set; }
    }
}
