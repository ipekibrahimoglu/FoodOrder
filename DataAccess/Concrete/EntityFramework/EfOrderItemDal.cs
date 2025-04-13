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
    public class EfOrderItemDal : EfGenericRepository<OrderItem, SouthwindContext>, IOrderItemDal
    {
        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            using var context = new SouthwindContext();
            var orderItems = await context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Select(oi => new OrderItemDto
                {
                    MenuItemId = oi.MenuItemId,
                    OrderId = oi.OrderId,
                    OrderItemId = oi.OrderItemId,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToListAsync();
            return orderItems;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();
            var result = await context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.MenuItem)
                .Select(oi => new OrderItemDto
                {
                    MenuItem = new MenuItemDto
                    {
                        Description = oi.MenuItem.Description,
                        ImageUrl = oi.MenuItem.ImageUrl,
                        MenuId = oi.MenuItem.MenuId,
                        MenuItemId = oi.MenuItem.MenuItemId,
                        Name = oi.MenuItem.Name,
                        Price = oi.MenuItem.Price
                    },
                    MenuItemId = oi.MenuItemId,
                    Order = new OrderDto
                    {
                        OrderDate = oi.Order.OrderDate,
                        OrderId = oi.Order.OrderId,
                        RestaurantId = oi.Order.RestaurantId,
                        Status = oi.Order.Status,
                        UserId = oi.Order.UserId
                    },
                    OrderId = oi.OrderId,
                    OrderItemId = oi.OrderItemId,
                    Price = oi.Price,
                    Quantity = oi.Quantity
                }).ToListAsync();
            return result;
        }
    }
}
