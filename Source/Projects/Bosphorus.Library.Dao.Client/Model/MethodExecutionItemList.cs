using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Dao.Client.ResultTransformer;

namespace Bosphorus.Dao.Client.Model
{
    public class MethodExecutionItemList: IExecutionItemList
    {
        public readonly IResultTransformer resultTransformer;

        public MethodExecutionItemList(IResultTransformer resultTransformer)
        {
            this.resultTransformer = resultTransformer;
        }

        public IList<IExecutionItem> List
        {
            get
            {
                IList<IExecutionItem> executionItemList = new List<IExecutionItem>();
                MethodInfo[] methodInfos = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                foreach (var methodInfo in methodInfos)
                {
                    IExecutionItem executionItem = new MethodExecutionItem(this, methodInfo, resultTransformer);
                    executionItemList.Add(executionItem);
                }

                return executionItemList;
            }
        }

    }
}
