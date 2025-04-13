using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class OrderDto: IDto
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public UserDto? User { get; set; }
        public RestaurantDto? Restaurant { get; set; }
        public IEnumerable<OrderItemDto>? OrderItems { get; set; } 
    }
}
