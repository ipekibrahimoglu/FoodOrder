using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public async Task<Order> GetByIdAsync(Guid id)
        {
            var order = await _orderDal.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception("Order has not been found!");
            }

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _orderDal.GetAllAsync();
            if (orders == null)
            {
                throw new Exception("Orders have not been found!");
            }

            return orders;
        }

        public async Task<IEnumerable<Order>> GetByConditionAsync(Expression<Func<Order, bool>> predicate)
        {
            var orders = await _orderDal.GetByConditionAsync(predicate);
            if (orders == null)
            {
                throw new Exception("Order(s) have not been found!");
            }

            return orders;
        }

        public async Task AddAsync(Order entity)
        {
           await _orderDal.AddAsync(entity);
        }

        public async Task UpdateAsync(Order entity)
        {
            var existingOrder =  await _orderDal.GetByIdAsync(entity.OrderId);
            if (existingOrder == null)
            {
                throw new Exception("There is no order like that!");
            }

            existingOrder.OrderItems = entity.OrderItems;
            await _orderDal.UpdateAsync(entity); // degismesi gerekebilir
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderToDelete = await _orderDal.GetByIdAsync(id);
            if (orderToDelete == null)
            {
                throw new Exception("No item to delete!");
            }

            await _orderDal.DeleteAsync(orderToDelete.OrderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            var orders = await _orderDal.GetOrdersByUserIdAsync(userId);
            if (orders == null)
            {
                throw new Exception("No order(s) to fetch!");
            }

            return orders;
        }
    }
}
