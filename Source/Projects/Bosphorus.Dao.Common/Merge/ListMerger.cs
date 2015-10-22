using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Common.Comparer;

namespace Bosphorus.Dao.Common.Merge
{
    internal class ListMerger<TItem>: IMerger<IList<TItem>>
    {
        private readonly GenericMerger genericMerger;
        private readonly IEqualityComparer<TItem> itemComparer;

        public ListMerger(GenericMerger genericMerger, IEqualityComparer<TItem> itemComparer)
        {
            this.genericMerger = genericMerger;
            this.itemComparer = itemComparer;
        }

        public IList<TItem> Merge(IList<TItem> intoModel, IList<TItem> model)
        {
            if (intoModel == null)
            {
                return model;
            }

            if (model == null)
            {
                return null;
            }

            List<TItem> deleteItems = intoModel.Where(item => !model.Contains(item, itemComparer)).ToList();
            deleteItems.ForEach(item => intoModel.Remove(item));

            List<Tuple<TItem, TItem>> matchedItems = GetMatchedItems(intoModel, model);
            foreach (Tuple<TItem, TItem> matchedItem in matchedItems)
            {
                TItem intoItem = matchedItem.Item1;
                TItem item = matchedItem.Item2;

                intoModel.Remove(intoItem);
                TItem updatedItem = genericMerger.Merge(intoItem, item);
                intoModel.Add(updatedItem);
            }

            List<TItem> newItems = model.Where(item => !intoModel.Contains(item, itemComparer)).ToList();
            newItems.ForEach(item => intoModel.Add(item));

            return intoModel;
        }

        private List<Tuple<TItem, TItem>> GetMatchedItems(IList<TItem> intoModel, IList<TItem> model)
        {
            IEnumerable<Tuple<TItem, TItem>> matchedItems =
                from intoItem in intoModel
                from item in model
                where intoItem.IsEqual(item, itemComparer)
                select new Tuple<TItem, TItem>(intoItem, item);

            return matchedItems.ToList();
        }
    }
}
