using System.Collections.Generic;

namespace Bosphorus.Dao.Client.Model
{
    class CompositeEceutionItemList: IExecutionItemList
    {
        private readonly IEnumerable<IExecutionItemList> items;

        public CompositeEceutionItemList(IList<IExecutionItemList> items)
        {
            this.items = items;
        }

        public IList<IExecutionItem> List
        {
            get
            {
                List<IExecutionItem> result = new List<IExecutionItem>();
                foreach (var item in items)
                {
                    IList<IExecutionItem> list = item.List;
                    result.AddRange(list);
                }

                return result;
            }
        }
    }
}
