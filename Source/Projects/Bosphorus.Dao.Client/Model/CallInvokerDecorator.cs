using System.Collections;
using Bosphorus.Common.Core.Call;

namespace Bosphorus.Dao.Client.Model
{
    public class CallInvokerDecorator: IExecutionItem
    {
        private readonly IExecutionItem decorated;
        private readonly CallInvoker callInvoker;

        public CallInvokerDecorator(IExecutionItem decorated, CallInvoker callInvoker)
        {
            this.decorated = decorated;
            this.callInvoker = callInvoker;
        }

        public IList Execute()
        {
            callInvoker.InvokeBeforeCall();
            IList result = decorated.Execute();
            callInvoker.InvokeAfterCall();
            return result;
        }

        public override string ToString()
        {
            return decorated.ToString();
        }
    }
}
