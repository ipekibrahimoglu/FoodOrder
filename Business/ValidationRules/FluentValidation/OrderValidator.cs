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
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.RestaurantId).NotEmpty();
            RuleFor(o => o.UserId).NotEmpty();
            RuleFor(o => o.OrderDate).NotEmpty();
            RuleFor(o => o.TotalPrice).NotEmpty().GreaterThan(0).Must(tp => ValidationHelpers
                .HasValidDecimalPrecision(tp, 18, 2));
            //RuleFor(o => o.Status).NotEmpty().WithMessage(Messages.OrderStatusRequired)
            //    .Must(s => s == "Pending" || s == "Preparing" || s =="Delivered" || s == "Cancelled")
            //    .WithMessage(Messages.OrderStatusInvalid);
        }
    }
}
