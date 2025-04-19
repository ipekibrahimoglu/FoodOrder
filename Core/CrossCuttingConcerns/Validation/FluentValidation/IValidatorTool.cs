using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public interface IValidatorTool
    {
        void Validate<T>(IValidator<T> validator, T entity);
    }
}
