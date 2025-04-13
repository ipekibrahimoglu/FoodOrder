using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public Guid UserId { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } 

        public string PhoneNumber { get; set; }
        public IEnumerable<ReviewDto>? Reviews { get; set; }
        public IEnumerable<RestaurantDto>? OwnedRestaurants { get; set; }
    }
}
