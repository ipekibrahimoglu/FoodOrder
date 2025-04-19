using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FullName).NotEmpty().MaximumLength(100);
            RuleFor(u => u.Email).NotEmpty().EmailAddress().MaximumLength(256);
            RuleFor(u => u.PasswordHash).NotEmpty().MinimumLength(6).MaximumLength(200);
            RuleFor(u => u.Role).NotEmpty().MaximumLength(20);
            RuleFor(u => u.PhoneNumber).MaximumLength(20).Matches(@"^\d{3}-\d{3}-\d{4}$")
                .When(u => !string.IsNullOrEmpty(u.PhoneNumber));
        }
    }
}
