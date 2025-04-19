using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MenuValidator : AbstractValidator<Menu>
    {

        public MenuValidator()
        {
            RuleFor(m => m.RestaurantId).NotEmpty();
            RuleFor(m => m.Description).MaximumLength(500);
            RuleFor(m => m.Name).NotEmpty().MaximumLength(100);
        }
    }
}
