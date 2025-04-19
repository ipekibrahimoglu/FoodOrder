using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
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
            RuleFor(p => p.Amount).NotEmpty().GreaterThan(0).WithMessage(Messages.PaymentAmountPositive).Must(a => ValidationHelpers
                .HasValidDecimalPrecision(a, 18, 2)).WithMessage(Messages.PaymentPrecision);
            RuleFor(p => p.PaymentMethod).NotEmpty().WithMessage(Messages.PaymentMethodRequired).MaximumLength(50);
        }
    }
}
