using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Dao.Client.ResultTransformer;

namespace Bosphorus.Dao.Client.Model
{
    public abstract class AbstractMethodExecutionItemList: IExecutionItemList
    {
        public readonly IResultTransformer resultTransformer;

        public AbstractMethodExecutionItemList(IResultTransformer resultTransformer)
        {
            this.resultTransformer = resultTransformer;
        }

        public IList<IExecutionItem> List
        {
            get
            {
                IList<IExecutionItem> executionItemList = new List<IExecutionItem>();
                MethodInfo[] methodInfos = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    IExecutionItem executionItem = new MethodExecutionItem(this, methodInfo, resultTransformer);
                    executionItemList.Add(executionItem);
                }

                return executionItemList;
            }
        }

        public override string ToString()
        {
            Type type = this.GetType();
            string fullName = type.FullName;
            string assemblyName = type.Assembly.GetName().Name;
            string remainder = fullName.Replace(assemblyName + "." , string.Empty);

            return remainder;
        }
    }
}
