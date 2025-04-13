using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
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
        public async Task<IDataResult<OrderItem>> GetByIdAsync(Guid id)
        {
            var orderItem = await _orderItemDal.GetByIdAsync(id);
            // orderItem var mi diye kontroller
            return new SuccessDataResult<OrderItem>(orderItem);
        }

        public async Task<IDataResult<IEnumerable<OrderItemDto>>> GetAllAsync()
        {
            var orderItems = await _orderItemDal.GetAllWithDetailsAsync();
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<OrderItemDto>>(orderItems);
        }

        public async Task<IDataResult<IEnumerable<OrderItem>>> GetByConditionAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            var orderItems = await _orderItemDal.GetByConditionAsync(predicate);
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<OrderItem>>(orderItems);

        }

        public async Task<IResult> AddAsync(OrderItem entity)
        {
           await _orderItemDal.AddAsync(entity);
           return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(OrderItem entity)
        {
            var existingOrderItem = await _orderItemDal.GetByIdAsync(entity.OrderItemId);
            // null mi kontrolleri
            existingOrderItem.Price = entity.Price;
            existingOrderItem.Quantity = entity.Quantity;
            await _orderItemDal.UpdateAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var orderItemToDelete = await _orderItemDal.GetByIdAsync(id);
            // null mi kontrolleri
            await _orderItemDal.DeleteAsync(orderItemToDelete.OrderItemId);
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<OrderItemDto>>> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = await _orderItemDal.GetOrderItemsByOrderIdAsync(orderId);
            return new SuccessDataResult<IEnumerable<OrderItemDto>>(orderItems);
        }
    }
}
