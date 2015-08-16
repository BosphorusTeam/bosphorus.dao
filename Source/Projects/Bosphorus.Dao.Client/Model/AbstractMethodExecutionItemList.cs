using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Common.Core.Call;
using Bosphorus.Dao.Client.ResultTransformer;
using Castle.Windsor;

namespace Bosphorus.Dao.Client.Model
{
    public abstract class AbstractMethodExecutionItemList: IExecutionItemList
    {
        public readonly IResultTransformer resultTransformer;
        private readonly CallInvoker callInvoker;

        public AbstractMethodExecutionItemList(IWindsorContainer container)
        {
            this.resultTransformer = container.Resolve<IResultTransformer>();
            this.callInvoker = container.Resolve<CallInvoker>();
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
                    IExecutionItem decoratedItem = new CallInvokerDecorator(executionItem, callInvoker);
                    executionItemList.Add(decoratedItem);
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
