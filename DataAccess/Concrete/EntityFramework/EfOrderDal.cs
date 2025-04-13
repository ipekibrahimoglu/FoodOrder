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

        public async Task<IEnumerable<OrderDto>> GetAllWithDetailsAsync()
        {
            using var context = new SouthwindContext();
            var result = await context.Orders
                .Include(o => o.User)
                .Include(o => o.Restaurant)
                .Include(o => o.OrderItems)
                .Select(o => new OrderDto
                {
                    OrderDate = o.OrderDate,
                    OrderId = o.OrderId,
                    RestaurantId = o.RestaurantId,
                    Status = o.Status,
                    TotalPrice = o.TotalPrice,
                    UserId = o.UserId,
                    User = new UserDto()
                    {
                        Email = o.User.Email,
                        FullName = o.User.FullName,
                        PhoneNumber = o.User.PhoneNumber,
                        Role = o.User.Role,
                        UserId = o.UserId
                    },
                    Restaurant = new RestaurantDto
                    {
                        Address = o.Restaurant.Address,
                        Name = o.Restaurant.Name,
                        RestaurantId = o.Restaurant.RestaurantId,
                        PhoneNumber = o.Restaurant.PhoneNumber
                    },
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        Price = oi.Price,
                        Quantity = oi.Quantity,
                        OrderItemId = oi.OrderItemId
                    }).ToList()

                }).ToListAsync();
            return result;
        }
    }
}
