using System.Collections;
using System.Collections.Generic;

namespace Bosphorus.Dao.Client.ResultTransformer
{
    class ChainedResultTransformer : IResultTransformer
    {
        private readonly IList<IResultTransformer> items;

        public ChainedResultTransformer()
        {
            this.items = BuildItems();
        }

        private IList<IResultTransformer> BuildItems()
        {
            IList<IResultTransformer> result = new List<IResultTransformer>();
            result.Add(new QueryableResultTransformer());
            result.Add(new ModelResultTransformer());

            return result;
        }

        public bool IsApplicable(object value)
        {
            foreach (var item in items)
            {
                if (item.IsApplicable(value))
                    return true;
            }

            return false;
        }

        public IList Transform(object value)
        {
            foreach (var item in items)
            {
                if (!item.IsApplicable(value))
                    continue;

                var result = item.Transform(value);
                return result;
            }

            return null;
        }
    }
}