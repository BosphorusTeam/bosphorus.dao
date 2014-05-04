using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bosphorus.Dao.Client.Model
{
    public abstract class AbstractExecutionItemList: IExecutionItemList
    {
        private readonly IList<IExecutionItem> executionItemList;

        protected AbstractExecutionItemList()
        {
            executionItemList = new List<IExecutionItem>();
        }

        protected void Add<TModel>(Expression<Func<IList<TModel>>> functionExpression)
        {
            string name = GetName<TModel>(functionExpression);

            Func<IList<TModel>> function = functionExpression.Compile();
            IExecutionItem executionItem = new EnumerableExceutionItem<TModel>(name, function);
            executionItemList.Add(executionItem);
        }

        protected void Add<TModel>(string methodName, Func<IQueryable<TModel>> function)
        {
            string name = GetName<TModel>(methodName);
            IExecutionItem executionItem = new EnumerableExceutionItem<TModel>(name, function);
            executionItemList.Add(executionItem);
        }

        protected void Add<TModel>(string methodName, Func<IEnumerable<TModel>> function)
        {
            string name = GetName<TModel>(methodName);
            IExecutionItem executionItem = new EnumerableExceutionItem<TModel>(name, function);
            executionItemList.Add(executionItem);
        }

        protected void Add<TModel>(Expression<Func<TModel>> functionExpression)
        {
            string name = GetName<TModel>(functionExpression);
            Func<TModel> function = functionExpression.Compile();
            IExecutionItem executionItem = new ModelExcecutionItem<TModel>(name, function);
            executionItemList.Add(executionItem);
        }

        private string GetName<TModel>(LambdaExpression expression)
        {
            MethodCallExpression methodCallExpression = expression.Body as MethodCallExpression;
            return GetName<TModel>(methodCallExpression.Method.Name);
        }

        private static string GetName<TModel>(string methodName)
        {
            string modelName = typeof(TModel).Name;
            string name = string.Format("{0} - {1}", modelName, methodName);
            return name;
        }

        public IList<IExecutionItem> List
        {
            get { return executionItemList; }
        }
    }
}