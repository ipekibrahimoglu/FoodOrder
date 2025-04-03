using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfGenericRepository<Payment, SouthwindContext>, IPaymentDal
    {
        public async Task<PaymentDto> GetPaymentByOrderIdAsync(Guid orderId)
        {
            using var context = new SouthwindContext();
            var payment = await context.Payments
                .Where(p => p.OrderId == orderId)
                .Select(p => new PaymentDto
                {
                    Amount = p.Amount,
                    IsSuccessful = p.IsSuccessful,
                    OrderId = p.OrderId,
                    PaymentDate = p.PaymentDate,
                    PaymentId = p.PaymentId,
                    PaymentMethod = p.PaymentMethod
                })
                .FirstOrDefaultAsync();
            return payment;
        }
    }
}
