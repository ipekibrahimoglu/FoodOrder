using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } //(enum: CreditCard, DebitCard, Cash, Online) (enum: CreditCard, DebitCard, Cash, Online)
        public bool IsSuccessful { get; set; }
        
    }
}
