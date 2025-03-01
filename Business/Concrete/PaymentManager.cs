using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public async Task<Payment> GetByIdAsync(Guid id)
        {
            var payment = await _paymentDal.GetByIdAsync(id);
            // null mi kontrolleri
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            var payments = await _paymentDal.GetAllAsync();
            // null mi kontrolleri
            return payments;
        }

        public async Task<IEnumerable<Payment>> GetByConditionAsync(Expression<Func<Payment, bool>> predicate)
        {
            var payments = await _paymentDal.GetByConditionAsync(predicate);
            // null mi kontrolleri
            return payments;
        }

        public async Task AddAsync(Payment entity)
        {
            await _paymentDal.AddAsync(entity);
        }

        public async Task UpdateAsync(Payment entity)
        {
            var existingPayment = await _paymentDal.GetByIdAsync(entity.PaymentId);
            // null mi kontrolleri
            existingPayment.Amount = entity.Amount;
            existingPayment.PaymentDate = entity.PaymentDate;
            existingPayment.PaymentMethod = existingPayment.PaymentMethod;
            existingPayment.IsSuccessful = entity.IsSuccessful;
            await _paymentDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var paymentToDelete = await _paymentDal.GetByIdAsync(id);
            // null mi kontrolleri
            await _paymentDal.DeleteAsync(paymentToDelete.OrderId);
        }
    }
}
