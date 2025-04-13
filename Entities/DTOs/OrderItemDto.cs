using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class OrderItemDto : IDto
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderDto? Order { get; set; }
        public MenuItemDto? MenuItem { get; set; }
    }
}
