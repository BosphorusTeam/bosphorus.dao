using System;
using System.Collections;

namespace Bosphorus.Dao.Client.Model
{
    public class ModelReturnExcecutionItem<TModel> : AbstractExecutionItem<TModel>
    {
        private readonly Func<TModel> function;

        public ModelReturnExcecutionItem(string prefix, string functionName, Func<TModel> function) 
            : base(prefix, functionName)
        {
            this.function = function;
        }

        public override IList Execute()
        {
            TModel model = function();

            IList list = new ArrayList();
            list.Add(model);
            return list;
        }
    }
}