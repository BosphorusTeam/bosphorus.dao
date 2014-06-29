using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.In
{
    //http://gedgei.wordpress.com/2012/01/21/creating-in-and-notin-extension-methods-for-nhibernate-3-linq-provider/
    public class HqlGenerator : BaseHqlGeneratorForMethod
    {
        public HqlGenerator()
        {
            SupportedMethods = new[]
        {
            ReflectionHelper.GetMethodDefinition(() => ObjectExtensions.In(null, (object[]) null)),
            ReflectionHelper.GetMethodDefinition(() => ObjectExtensions.In<object>(null, (IQueryable<object>) null)),
            ReflectionHelper.GetMethodDefinition(() => ObjectExtensions.NotIn<object>(null, (object[]) null)),
            ReflectionHelper.GetMethodDefinition(() => ObjectExtensions.NotIn<object>(null, (IQueryable<object>) null))
        };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            var value = visitor.Visit(arguments[0]).AsExpression();
            HqlTreeNode inClauseNode;

            if (arguments[1] is ConstantExpression)
                inClauseNode = BuildFromArray((Array)((ConstantExpression)arguments[1]).Value, treeBuilder);
            else
                inClauseNode = BuildFromExpression(arguments[1], visitor);

            HqlTreeNode inClause = treeBuilder.In(value, inClauseNode);

            if (method.Name == "NotIn")
                inClause = treeBuilder.BooleanNot((HqlBooleanExpression)inClause);

            return inClause;
        }

        private HqlTreeNode BuildFromExpression(Expression expression, IHqlExpressionVisitor visitor)
        {
            //TODO: check if it's a valid expression for in clause, i.e. it selects only one column
            return visitor.Visit(expression).AsExpression();
        }

        private HqlTreeNode BuildFromArray(Array valueArray, HqlTreeBuilder treeBuilder)
        {
            var elementType = valueArray.GetType().GetElementType();

            if (!elementType.IsValueType && elementType != typeof(string))
                throw new ArgumentException("Only primitives and strings can be used");

            Type enumUnderlyingType = elementType.IsEnum ? Enum.GetUnderlyingType(elementType) : null;
            var variants = new HqlExpression[valueArray.Length];

            for (int index = 0; index < valueArray.Length; index++)
            {
                var variant = valueArray.GetValue(index);
                var val = variant;

                if (elementType.IsEnum)
                    val = Convert.ChangeType(variant, enumUnderlyingType);

                variants[index] = treeBuilder.Constant(val);
            }

            return treeBuilder.DistinctHolder(variants);
        }
    }
}
