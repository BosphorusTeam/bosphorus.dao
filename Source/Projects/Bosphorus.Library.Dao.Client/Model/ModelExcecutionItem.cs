using System;
using System.Collections;

namespace Bosphorus.Dao.Client.Model
{
    public class ModelExcecutionItem<TModel> : AbstractExecutionItem
    {
        private readonly Func<TModel> function;

        public ModelExcecutionItem(string name, Func<TModel> function) 
            : base(name)
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