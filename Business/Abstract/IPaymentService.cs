using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        Task<IDataResult<Payment>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<PaymentDto>>> GetAllAsync();
        Task<IDataResult<IEnumerable<Payment>>> GetByConditionAsync(Expression<Func<Payment, bool>> predicate);
        Task<IResult> AddAsync(Payment entity);
        Task<IResult> UpdateAsync(Payment entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<PaymentDto>> GetPaymentByOrderIdAsync(Guid id);
    }
}
