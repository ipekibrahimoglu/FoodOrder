using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public async Task<IDataResult<Order>> GetByIdAsync(Guid id)
        {
            var order = await _orderDal.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception("Order has not been found!");
            }

            return new SuccessDataResult<Order>(order);
        }

        public async Task<IDataResult<IEnumerable<OrderDto>>> GetAllAsync()
        {
            var orders = await _orderDal.GetAllWithDetailsAsync();
            if (orders == null)
            {
                throw new Exception("Orders have not been found!");
            }

            return new SuccessDataResult<IEnumerable<OrderDto>>(orders);
        }

        public async Task<IDataResult<IEnumerable<Order>>> GetByConditionAsync(Expression<Func<Order, bool>> predicate)
        {
            var orders = await _orderDal.GetByConditionAsync(predicate);
            if (orders == null)
            {
                throw new Exception("Order(s) have not been found!");
            }

            return new SuccessDataResult<IEnumerable<Order>>(orders);
        }

        public async Task<IResult> AddAsync(Order entity)
        {
           await _orderDal.AddAsync(entity);
           return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Order entity)
        {
            var existingOrder =  await _orderDal.GetByIdAsync(entity.OrderId);
            if (existingOrder == null)
            {
                throw new Exception("There is no order like that!");
            }

            existingOrder.OrderItems = entity.OrderItems;
            await _orderDal.UpdateAsync(entity); // degismesi gerekebilir
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var orderToDelete = await _orderDal.GetByIdAsync(id);
            if (orderToDelete == null)
            {
                throw new Exception("No item to delete!");
            }

            await _orderDal.DeleteAsync(orderToDelete.OrderId);
            return new SuccessResult();
        }

        public async Task<IDataResult<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await _orderDal.GetOrdersByUserIdAsync(userId);
            if (orders == null)
            {
                throw new Exception("No order(s) to fetch!");
            }

            return new SuccessDataResult<IEnumerable<OrderDto>>(orders);
        }


        public async Task<IDataResult<IEnumerable<OrderDto>>> GetOrdersByRestaurantIdAsync(Guid id)
        {
            return new SuccessDataResult<IEnumerable<OrderDto>>(await _orderDal.GetOrdersByRestaurantIdAsync(id));
        }
    }
}
