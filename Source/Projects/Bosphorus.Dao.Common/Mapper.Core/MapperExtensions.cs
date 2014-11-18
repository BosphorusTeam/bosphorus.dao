using System;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Common.Instantiator;

namespace Bosphorus.Dao.Common.Mapper.Core
{
    public static class MapperExtensions
    {
        private static readonly IInstantiator instantiator;

        static MapperExtensions()
        {
            instantiator = ServiceRegistry.Get<IInstantiator>();
        }

        public static TTarget Map<TTarget>(this IMapper extended, object source)
        {
            Type targetType = typeof (TTarget);
            object result = Map(extended, source, targetType);
            return (TTarget) result;
        }

        public static object Map(this IMapper extended, object source, Type targetType)
        {
            object target = instantiator.Create(targetType);
            object result = Map(extended, source, targetType, target);
            return result;
        }

        public static object Map(this IMapper extended, object source, Type targetType, object target)
        {
            Type sourceType = source.GetType();
            extended.Map(sourceType, source, targetType, target);
            return target;
        }
    }
}
