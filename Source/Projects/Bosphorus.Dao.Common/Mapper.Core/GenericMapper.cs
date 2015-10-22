using System;
using Bosphorus.Dao.Common.Mapper.Flattener;
using Bosphorus.Dao.Common.Mapper.Unflattener;

namespace Bosphorus.Dao.Common.Mapper.Core
{
    public class GenericMapper
    {
        private readonly GenericFlattener genericFlattener;
        private readonly GenericUnflattener genericUnflattener;

        public GenericMapper(GenericFlattener genericFlattener, GenericUnflattener genericUnflattener)
        {
            this.genericFlattener = genericFlattener;
            this.genericUnflattener = genericUnflattener;
        }

        public TTarget Flatten<TSource, TTarget>(TSource source)
        {
            TTarget result = genericFlattener.Map<TSource, TTarget>(source);
            return result;
        }

        public object Flatten(Type sourceType, Type targetType, object source)
        {
            object result = genericFlattener.Map(sourceType, targetType, source);
            return result;
        }

        public TTarget Unflatten<TSource, TTarget>(TSource source)
        {
            TTarget result = genericUnflattener.Map<TSource, TTarget>(source);
            return result;
        }

        public object Unflatten(Type sourceType, Type targetType, object source)
        {
            object result = genericUnflattener.Map(sourceType, targetType, source);
            return result;
        }

    }
}
