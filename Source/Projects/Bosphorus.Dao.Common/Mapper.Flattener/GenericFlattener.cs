using System;
using System.Diagnostics;
using System.Reflection;
using Bosphorus.Common.Clr.Symbol;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Flattener
{
    public class GenericFlattener
    {
        private readonly IWindsorContainer container;
        private readonly MethodInfo genericMethod;

        public GenericFlattener(IWindsorContainer container)
        {
            this.container = container;
            this.genericMethod = Reflection<GenericFlattener>.GetMethodInfo(mapper => mapper.Map<object, object>(null)).GetGenericMethodDefinition();
        }

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            IFlattener<TSource, TTarget> flattener = container.Resolve<IFlattener<TSource, TTarget>>();
            TTarget result = flattener.Map(source);
            return result;
        }

        [DebuggerStepThrough]
        public object Map(Type sourceType, Type targetType, object source)
        {
            MethodInfo methodInfo = genericMethod.MakeGenericMethod(sourceType, targetType);
            object target = methodInfo.Invoke(this, new[] { source });
            return target;
        }

    }
}
