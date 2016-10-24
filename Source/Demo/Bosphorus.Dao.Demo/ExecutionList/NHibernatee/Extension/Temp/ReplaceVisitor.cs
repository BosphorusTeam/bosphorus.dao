using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo.ExecutionList.NHibernatee.Extension.Temp
{
    public class ReplaceVisitor: ExpressionVisitor
    {
        private readonly MethodInfo joinMethod;

        public ReplaceVisitor()
        {
            IQueryable<object> customers = null;
            IQueryable<object> accounts = null;
            joinMethod = Reflection<IQueryable<object>>.GetMethodInfo(objects => objects.Join(accounts, x => x, null, (customer, account) => customer)).GetGenericMethodDefinition();
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            bool genericMethod = node.Method.IsGenericMethod;
            if (!genericMethod)
            {
                return base.VisitMethodCall(node);
            }

            MethodInfo genericMethodDefinition = node.Method.GetGenericMethodDefinition();
            if (genericMethodDefinition != joinMethod)
            {
                return base.VisitMethodCall(node);
            }


            IQueryable<Customer> customers = (IQueryable<Customer>)(node.Arguments[0] as ConstantExpression).Value;
            IQueryable<Account> accounts = (IQueryable<Account>) (node.Arguments[1] as ConstantExpression).Value;

            IQueryable<Customer> filteredCustomer = GetOptimizedExpression<Customer, Account, int, Customer>(node.Arguments);
            var temp =
                from customer in filteredCustomer
                from account in accounts
                where customer.Id == account.Customer.Id
                select new {customer, account};

            //Expression temp = (expressions[4] as UnaryExpression).Operand;
            //Expression<Func<TMaster, TJoined, TResult>> func = (Expression<Func<TMaster, TJoined, TResult>>) temp;
            //IQueryable<TResult> selectMany = queryable.SelectMany(master => joineds, func);

            return temp.Expression;
        }

        private IQueryable<TMaster> GetOptimizedExpression<TMaster, TJoined, TId, TResult>(ReadOnlyCollection<Expression> expressions)
        {
            IQueryable<TJoined> joineds = GetAsQueryable<TJoined>(expressions[1]);
            Expression<Func<TJoined, TId>> joinSelect = GetAsFunction<TJoined, TId>(expressions[3]);
            List<TId> ids = joineds.Select(joinSelect).Distinct().ToList();

            IQueryable<TMaster> masters = GetAsQueryable<TMaster>(expressions[0]);
            Expression<Func<TMaster, TId>> masterSelect = GetAsFunction<TMaster, TId>(expressions[2]);
            Expression<Func<TMaster, bool>> masterWhere = GetExpression<TMaster, TId>(ids, masterSelect);
            IQueryable<TMaster> queryable = masters.Where(masterWhere);

            return queryable;
        }

        static Expression<Func<TMaster, bool>> GetExpression<TMaster, TId>(List<TId> ids, Expression<Func<TMaster, TId>> masterSelect)
        {
            MemberExpression expression = masterSelect.Body as MemberExpression;
            PropertyInfo propertyInfo = expression.Member as PropertyInfo;

            ParameterExpression parameterExpression = Expression.Parameter(typeof(TMaster), "master");
            MemberExpression memberExpression = Expression.Property(parameterExpression, propertyInfo);

            MethodInfo method = Reflection<List<TId>>.GetMethodInfo(list => list.Contains(default(TId)));
            ConstantExpression constantExpression = Expression.Constant(ids, typeof(List<TId>));
            MethodCallExpression containsMethodExpression = Expression.Call(constantExpression, method, memberExpression);

            return Expression.Lambda<Func<TMaster, bool>>(containsMethodExpression, parameterExpression);
        }

        private IQueryable<TModel> GetAsQueryable<TModel>(Expression expression)
        {
            object value = ((ConstantExpression)expression).Value;
            return (IQueryable<TModel>)value;
        }

        private Expression<Func<TSource, TResult>> GetAsFunction<TSource, TResult>(Expression expression)
        {
            Expression operand = ((UnaryExpression) expression).Operand;
            return (Expression<Func<TSource, TResult>>) operand;
        }
    }
}
