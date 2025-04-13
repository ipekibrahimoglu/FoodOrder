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
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public async Task<IDataResult<Payment>> GetByIdAsync(Guid id)
        {
            var payment = await _paymentDal.GetByIdAsync(id);
            // null mi kontrolleri
            return new SuccessDataResult<Payment>(payment);
        }

        public async Task<IDataResult<IEnumerable<PaymentDto>>> GetAllAsync()
        {
            var payments = await _paymentDal.GetAllWithDetailsAsync();
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IDataResult<IEnumerable<Payment>>> GetByConditionAsync(Expression<Func<Payment, bool>> predicate)
        {
            var payments = await _paymentDal.GetByConditionAsync(predicate);
            // null mi kontrolleri
            return new SuccessDataResult<IEnumerable<Payment>>(payments);
        }

        public async Task<IResult> AddAsync(Payment entity)
        {
            await _paymentDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(Payment entity)
        {
            var existingPayment = await _paymentDal.GetByIdAsync(entity.PaymentId);
            // null mi kontrolleri
            existingPayment.Amount = entity.Amount;
            existingPayment.PaymentDate = entity.PaymentDate;
            existingPayment.PaymentMethod = existingPayment.PaymentMethod;
            existingPayment.IsSuccessful = entity.IsSuccessful;
            await _paymentDal.UpdateAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var paymentToDelete = await _paymentDal.GetByIdAsync(id);
            // null mi kontrolleri
            await _paymentDal.DeleteAsync(paymentToDelete.OrderId);
            return new SuccessResult();
        }

        public async Task<IDataResult<PaymentDto>> GetPaymentByOrderIdAsync(Guid id)
        {
            return new SuccessDataResult<PaymentDto>(await _paymentDal.GetPaymentByOrderIdAsync(id));
        }
    }
}
