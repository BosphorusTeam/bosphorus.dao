using System.Linq;
using System.Linq.Expressions;

namespace Bosphorus.Dao.Demo.ExecutionList.NHibernatee.Extension.Temp
{
    public static class QueryableExtensions
    {
        private static readonly ReplaceVisitor visitor = new ReplaceVisitor();

        public static IQueryable<TModel> Optimize<TModel>(this IQueryable<TModel> extended)
        {
            IQueryProvider queryProvider = extended.Provider;
            Expression expression = extended.Expression;
            Expression optimizedExpression = visitor.Visit(expression);
            IQueryable<TModel> result = queryProvider.CreateQuery<TModel>(optimizedExpression);

            return result;
        }
    }
}
