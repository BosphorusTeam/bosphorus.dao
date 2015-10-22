using System.Collections.Generic;

namespace Bosphorus.Dao.Common.Instantiator
{
    internal class ListInstantiator<TItem> : IInstantiator<IList<TItem>>
    {
        public IList<TItem> Create()
        {
            IList<TItem> result = new List<TItem>();
            return result;
        }
    }
}