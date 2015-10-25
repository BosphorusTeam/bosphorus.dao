using System;
using System.Diagnostics;
using System.Reflection;
using Bosphorus.Common.Clr.Symbol;
using Bosphorus.Dao.Common.Mapper.Flattener.Decoration;
using Bosphorus.Dao.Common.Mapper.Flattener.Override;
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

        [DebuggerStepThrough]
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            IFlattener<TSource, TTarget> flattener = container.Resolve<IFlattener<TSource, TTarget>>();
            TTarget target = flattener.Map(source);

            IFlattenerOverride<TSource, TTarget> flattenerOverride = container.Resolve<IFlattenerOverride<TSource, TTarget>>();
            flattenerOverride.Map(source, target);

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
