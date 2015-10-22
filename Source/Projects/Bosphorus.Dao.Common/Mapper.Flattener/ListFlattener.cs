using System.Collections.Generic;
using Bosphorus.Dao.Common.Instantiator;

namespace Bosphorus.Dao.Common.Mapper.Flattener
{
    internal class ListFlattener<TSource, TTarget> : IFlattener<IList<TSource>, IList<TTarget>>
    {
        private readonly GenericFlattener genericFlattener;
        private readonly IInstantiator<IList<TTarget>> listInstantiator;

        public ListFlattener(GenericFlattener genericFlattener, IInstantiator<IList<TTarget>> listInstantiator)
        {
            this.genericFlattener = genericFlattener;
            this.listInstantiator = listInstantiator;
        }

        public IList<TTarget> Map(IList<TSource> source)
        {
            IList<TTarget> target = listInstantiator.Create();
            foreach (var sourceItem in source)
            {
                TTarget targetItem = genericFlattener.Map<TSource, TTarget>(sourceItem);
                target.Add(targetItem);
            }

            return target;
        }
    }
}
