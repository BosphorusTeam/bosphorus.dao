using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Dao.Client.Model
{
    public class EnumerableExceutionItem<TModel> : AbstractExecutionItem
    {
        private readonly Func<IEnumerable<TModel>> function;

        public EnumerableExceutionItem(string name, Func<IEnumerable<TModel>> function) 
            : base(name)
        {
            this.function = function;
        }

        public override IList Execute()
        {
            IEnumerable<TModel> enumerable = function();
            return enumerable.ToList();
        }
    }
}