using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[]? SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterception>(true).ToList();
            var methodAttributes = method.GetCustomAttributes<MethodInterception>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes
                .Cast<IInterceptor>() 
                .ToArray();           
        }
    }
}