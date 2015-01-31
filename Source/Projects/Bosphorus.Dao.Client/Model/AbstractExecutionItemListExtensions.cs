using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bosphorus.Dao.Client.Model
{
    public static class AbstractExecutionItemListExtensions
    {
        public static void Add<TModel>(this AbstractExecutionItemList abstractExecutionItemList, Expression<Func<IEnumerable<TModel>>> enumerableReturnFunction)
        {
            string functionName = GetFunctionName(enumerableReturnFunction);
            abstractExecutionItemList.Add(functionName, enumerableReturnFunction);
        }

        private static string GetFunctionName<TModel>(Expression<Func<IEnumerable<TModel>>> enumerableReturnFunctionExpression)
        {
            MethodCallExpression methodCallExpression = (MethodCallExpression)enumerableReturnFunctionExpression.Body;
            string result = methodCallExpression.Method.Name;
            return result;
        }

        public static void Add<TModel>(this AbstractExecutionItemList abstractExecutionItemList, Expression<Func<IQueryable<TModel>>> queryableReturnFunction)
        {
            string functionName = GetFunctionName(queryableReturnFunction);
            abstractExecutionItemList.Add(functionName, queryableReturnFunction);
        }

        private static string GetFunctionName<TModel>(Expression<Func<IQueryable<TModel>>> expression)
        {
            MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
            Expression rightExpression = methodCallExpression.Arguments[1];
            string result = rightExpression.ToString();
            return result;
        }

        public static void Add<TModel>(this AbstractExecutionItemList abstractExecutionItemList, Expression<Func<TModel>> modelReturnFunction)
        {
            string functionName = GetFunctionName(modelReturnFunction);
            abstractExecutionItemList.Add(functionName, modelReturnFunction);
        }

        private static string GetFunctionName<TModel>(Expression<Func<TModel>> expression)
        {
            MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
            string result = methodCallExpression.Method.Name;
            return result;
        }
    }
}
