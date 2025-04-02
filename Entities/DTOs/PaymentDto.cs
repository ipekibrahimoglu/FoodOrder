using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class PaymentDto : IDto  
    {
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } //(enum: CreditCard, DebitCard, Cash, Online) (enum: CreditCard, DebitCard, Cash, Online)
        public bool IsSuccessful { get; set; }
    }
}
