using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderItemDal : EfGenericRepository<OrderItem>, IOrderItemDal
    {
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            using var context = new SouthwindContext();
            var orderItems = await context.OrderItems.Where(oi => oi.OrderId == orderId).ToListAsync();
            return orderItems;
        }
    }
}
