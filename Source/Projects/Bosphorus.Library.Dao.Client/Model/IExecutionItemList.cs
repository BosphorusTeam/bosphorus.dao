using System.Collections.Generic;

namespace Bosphorus.Dao.Client.Model
{
    public interface IExecutionItemList
    {
        IList<IExecutionItem> List { get; }
    }
}