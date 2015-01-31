using System.Collections.Generic;

namespace Bosphorus.Dao.Client.Model
{
    public class CompositeExecutionItemList: IExecutionItemList
    {
        private readonly IEnumerable<IExecutionItemList> items;

        public CompositeExecutionItemList(IList<IExecutionItemList> items)
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
