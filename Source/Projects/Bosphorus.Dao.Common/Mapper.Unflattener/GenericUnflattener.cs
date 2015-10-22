using System;
using System.Diagnostics;
using System.Reflection;
using Bosphorus.Common.Clr.Symbol;
using Bosphorus.Dao.Common.Mapper.Flattener;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Unflattener
{
    public class GenericUnflattener
    {
        private readonly IWindsorContainer container;
        private readonly MethodInfo genericMethod;

        public GenericUnflattener(IWindsorContainer container)
        {
            this.container = container;
            this.genericMethod = Reflection<GenericUnflattener>.GetMethodInfo(mapper => mapper.Map<object, object>(null)).GetGenericMethodDefinition();
        }

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            IUnflattener<TSource, TTarget> flattener = container.Resolve<IUnflattener<TSource, TTarget>>();
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
