using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Dao.Client.Model
{
    public class EnumerableReturnExceutionItem<TModel> : AbstractExecutionItem<TModel>
    {
        private readonly Func<IEnumerable<TModel>> function;

        public EnumerableReturnExceutionItem(string prefix, string functionName, Func<IEnumerable<TModel>> function) 
            : base(prefix, functionName)
        {
            this.function = function;
        }

        public override IList Execute()
        {
            IEnumerable<TModel> enumerable = function();
            List<TModel> result = enumerable.ToList();

            return result;
        }
    }
}