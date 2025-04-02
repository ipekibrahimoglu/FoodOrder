using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public Guid UserId { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } //enum kullanarak yaz core katmanini entegre ettiginde (enum: Admin, Customer, RestaurantOwner)

        public string PhoneNumber { get; set; }
    }
}
