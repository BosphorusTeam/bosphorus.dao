using System.Collections.Generic;
using Bosphorus.Dao.Common.Instantiator;

namespace Bosphorus.Dao.Common.Mapper.Unflattener
{
    internal class ListUnflattener<TSource, TTarget> : IUnflattener<IList<TSource>, IList<TTarget>>
    {
        private readonly GenericUnflattener genericUnflattener;
        private readonly IInstantiator<IList<TTarget>> targetInstantiator;

        public ListUnflattener(GenericUnflattener genericUnflattener, IInstantiator<IList<TTarget>> targetInstantiator)
        {
            this.genericUnflattener = genericUnflattener;
            this.targetInstantiator = targetInstantiator;
        }

        public IList<TTarget> Map(IList<TSource> source)
        {
            IList<TTarget> target = targetInstantiator.Create();
            foreach (TSource sourceItem in source)
            {
                TTarget targetItem = genericUnflattener.Map<TSource, TTarget>(sourceItem);
                target.Add(targetItem);
            }

            return target;
        }
    }
}
