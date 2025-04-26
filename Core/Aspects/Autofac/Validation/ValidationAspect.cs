using Castle.DynamicProxy;
using FluentValidation;
using Core.Utilities.Interceptors;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir validator sınıfı değil.");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType)!;

            var entityType = _validatorType.BaseType!.GetGenericArguments()[0];

            var entitiesToValidate = invocation.Arguments
                .Where(arg => arg != null && arg.GetType() == entityType);

            foreach (var entity in entitiesToValidate)
            {
                var method = typeof(AbstractValidator<>)
                    .MakeGenericType(entityType)
                    .GetMethod("ValidateAndThrow", new[] { entityType });

                method?.Invoke(validator, new[] { entity });
            }
        }
    }
}