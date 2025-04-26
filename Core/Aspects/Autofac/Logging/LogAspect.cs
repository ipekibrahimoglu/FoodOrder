using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Method çalışmadan önce: {invocation.Method.Name}");
            invocation.Proceed();
            Console.WriteLine($"Method çalıştıktan sonra: {invocation.Method.Name}");
        }
    }
}
