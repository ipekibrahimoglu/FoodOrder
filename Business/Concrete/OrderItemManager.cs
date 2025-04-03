using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }
        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            var orderItem = await _orderItemDal.GetByIdAsync(id);
            // orderItem var mi diye kontroller
            return orderItem;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            var orderItems = await _orderItemDal.GetAllAsync();
            // null mi kontrolleri
            return orderItems;
        }

        public async Task<IEnumerable<OrderItem>> GetByConditionAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            var orderItems = await _orderItemDal.GetByConditionAsync(predicate);
            // null mi kontrolleri
            return orderItems;

        }

        public async Task AddAsync(OrderItem entity)
        {
           await _orderItemDal.AddAsync(entity);
        }

        public async Task UpdateAsync(OrderItem entity)
        {
            var existingOrderItem = await _orderItemDal.GetByIdAsync(entity.OrderItemId);
            // null mi kontrolleri
            existingOrderItem.Price = entity.Price;
            existingOrderItem.Quantity = entity.Quantity;
            await _orderItemDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderItemToDelete = await _orderItemDal.GetByIdAsync(id);
            // null mi kontrolleri
            await _orderItemDal.DeleteAsync(orderItemToDelete.OrderItemId);
        }

        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = await _orderItemDal.GetOrderItemsByOrderIdAsync(orderId);
            return orderItems;
        }
    }
}
