using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; } //enum ile guncelle  (enum: Pending, Preparing, Delivered, Cancelled)

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
