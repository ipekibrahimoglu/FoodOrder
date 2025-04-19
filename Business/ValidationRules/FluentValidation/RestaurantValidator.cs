using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RestaurantValidator : AbstractValidator<Restaurant>
    {
        public RestaurantValidator()
        {
            RuleFor(r => r.OwnerId).NotEmpty();
            RuleFor(r => r.Name).NotEmpty().WithMessage(Messages.RestaurantNameRequired).MaximumLength(150);
            RuleFor(r => r.Description).MaximumLength(500);
            RuleFor(r => r.Address).NotEmpty().WithMessage(Messages.RestaurantAddressRequired).MaximumLength(200);
            RuleFor(r => r.PhoneNumber).MaximumLength(20).Matches(@"^\d{3}-\d{3}-\d{4}$")
                .When(r => !string.IsNullOrEmpty(r.PhoneNumber));
        }
    }
}
