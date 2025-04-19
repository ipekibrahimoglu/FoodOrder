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
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FullName).NotEmpty().WithMessage(Messages.UserFullNameRequired).MaximumLength(100);
            RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.UserEmailRequired).EmailAddress().WithMessage(Messages.UserEmailInvalid).MaximumLength(256);
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage(Messages.UserPasswordRequired).MinimumLength(6).MaximumLength(200);
            RuleFor(u => u.Role).NotEmpty().WithMessage(Messages.UserRoleRequired).MaximumLength(20);
            RuleFor(u => u.PhoneNumber).MaximumLength(20).Matches(@"^\d{3}-\d{3}-\d{4}$")
                .When(u => !string.IsNullOrEmpty(u.PhoneNumber));
        }
    }
}
