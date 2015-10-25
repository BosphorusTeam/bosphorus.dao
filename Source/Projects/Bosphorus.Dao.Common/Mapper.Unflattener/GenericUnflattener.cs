using System;
using System.Diagnostics;
using System.Reflection;
using Bosphorus.Common.Clr.Symbol;
using Bosphorus.Dao.Common.Mapper.Flattener;
using Bosphorus.Dao.Common.Mapper.Unflattener.Override;
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

        [DebuggerStepThrough]
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            IUnflattener<TSource, TTarget> flattener = container.Resolve<IUnflattener<TSource, TTarget>>();
            TTarget target = flattener.Map(source);

            IUnflattenerOverride<TSource, TTarget> unflattenerOverride = container.Resolve<IUnflattenerOverride<TSource, TTarget>>();
            unflattenerOverride.Map(source, target);

            return target;
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
