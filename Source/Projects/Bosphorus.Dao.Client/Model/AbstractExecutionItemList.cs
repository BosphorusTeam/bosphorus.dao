using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bosphorus.Dao.Client.Model
{
    public abstract class AbstractExecutionItemList: IExecutionItemList
    {
        private readonly string prefix;
        private readonly IList<IExecutionItem> executionItemList;

        protected AbstractExecutionItemList(string prefix)
        {
            this.prefix = prefix;
            executionItemList = new List<IExecutionItem>();
        }

        protected AbstractExecutionItemList()
            : this(string.Empty)
        {
        }

        public void Add<TModel>(string name, Expression<Func<IEnumerable<TModel>>> enumerableReturnFunction)
        {
            Func<IEnumerable<TModel>> function = enumerableReturnFunction.Compile();
            IExecutionItem executionItem = new EnumerableReturnExceutionItem<TModel>(prefix, name, function);
            executionItemList.Add(executionItem);
        }

        public void Add<TModel>(string name, Expression<Func<IQueryable<TModel>>> queryableReturnFunction)
        {
            Func<IEnumerable<TModel>> function = queryableReturnFunction.Compile();
            IExecutionItem executionItem = new EnumerableReturnExceutionItem<TModel>(prefix, name, function);
            executionItemList.Add(executionItem);
        }

        public void Add<TModel>(string name, Expression<Func<TModel>> modelReturnFunction)
        {
            Func<TModel> function = modelReturnFunction.Compile();
            IExecutionItem executionItem = new ModelReturnExcecutionItem<TModel>(prefix, name, function);
            executionItemList.Add(executionItem);
        }

        public IList<IExecutionItem> List
        {
            get { return executionItemList; }
        }
    }
}