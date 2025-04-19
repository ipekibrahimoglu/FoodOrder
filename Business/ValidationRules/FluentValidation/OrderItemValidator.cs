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
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(oi => oi.OrderId).NotEmpty();
            RuleFor(oi => oi.MenuItemId).NotEmpty();
            RuleFor(oi => oi.Quantity).GreaterThan(0).WithMessage(Messages.OrderItemQuantityPositive);
            RuleFor(oi => oi.Price).GreaterThan(0).WithMessage(Messages.OrderItemPricePositive).Must(p => ValidationHelpers
                .HasValidDecimalPrecision(p, 18, 2)).WithMessage(Messages.OrderItemPricePrecision);
        }
    }
}
