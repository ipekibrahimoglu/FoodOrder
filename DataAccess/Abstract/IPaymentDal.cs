using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IPaymentDal : IGenericRepository<Payment>
{
    Task<PaymentDto> GetPaymentByOrderIdAsync(Guid orderId);
    Task<IEnumerable<PaymentDto>> GetAllWithDetailsAsync();
}