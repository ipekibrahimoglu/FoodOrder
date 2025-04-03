using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfGenericRepository<Order, SouthwindContext>, IOrderDal
    {
        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            using var context = new SouthwindContext();
            var orders = await context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    UserId = o.UserId,
                    OrderDate = o.OrderDate,
                    
                    RestaurantId = o.RestaurantId,
                    Status = o.Status,
                    TotalPrice = o.TotalPrice,
                    
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        OrderItemId = oi.OrderItemId,
                        MenuItemId = oi.MenuItemId,
                        OrderId = oi.OrderId,
                        Price = oi.Price,
                        Quantity = oi.Quantity

                    }).ToList()

                }).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByRestaurantIdAsync(Guid restaurantId)
        {
            using var context = new SouthwindContext();
            var orders = await context.Orders
                .Where(o => o.RestaurantId == restaurantId)
                .Include(o => o.OrderItems)
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    RestaurantId = o.RestaurantId,
                    Status = o.Status,
                    TotalPrice = o.TotalPrice,
                    UserId = o.UserId,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        MenuItemId = oi.MenuItemId,
                        OrderId = oi.OrderId,
                        OrderItemId = oi.OrderItemId,
                        Price = oi.Price,
                        Quantity = oi.Quantity
                    }).ToList()
                }).ToListAsync();
            return orders;
        }
    }
}
