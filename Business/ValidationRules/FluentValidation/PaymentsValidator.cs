using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Helpers;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentsValidator : AbstractValidator<Payment>
    {
        public PaymentsValidator()
        {
            RuleFor(p => p.OrderId).NotEmpty();
            RuleFor(p => p.PaymentDate).NotEmpty();
            RuleFor(p => p.Amount).NotEmpty().GreaterThan(0).Must(a => ValidationHelpers
                .HasValidDecimalPrecision(a, 18, 2));
            RuleFor(p => p.PaymentMethod).NotEmpty().MaximumLength(50);
        }
    }
}
