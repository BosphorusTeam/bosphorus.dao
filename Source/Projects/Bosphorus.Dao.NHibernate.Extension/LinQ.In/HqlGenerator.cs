using System;
using System.Collections;
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
            HqlExpression value = visitor.Visit(arguments[0]).AsExpression();
            HqlTreeNode inClauseNode = BuildInClause(arguments, treeBuilder, visitor);

            HqlTreeNode inClause = treeBuilder.In(value, inClauseNode);

            if (method.Name == "NotIn")
                inClause = treeBuilder.BooleanNot((HqlBooleanExpression)inClause);

            return inClause;
        }

        private HqlTreeNode BuildInClause(ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            ConstantExpression constantExpression = arguments[1] as ConstantExpression;
            if (constantExpression == null)
            {
                HqlTreeNode result = BuildFromExpression(arguments[1], visitor);
                return result;
            }

            IEnumerable valueArray = (IEnumerable)constantExpression.Value;
            Type elementType = GetElementType(valueArray);

            if (elementType.IsValueType || elementType == typeof(string))
            {
                HqlTreeNode result = BuildFromArray(valueArray, treeBuilder, elementType);
                return result;
            }

            HqlTreeNode hqlTreeNode = BuildFromExpression(arguments[1], visitor);
            return hqlTreeNode;
        }

        private Type GetElementType(IEnumerable valueArray)
        {
            Type valueArrayType = valueArray.GetType();

            if (valueArray is Array)
            {
                Type elementType = valueArrayType.GetElementType();
                return elementType;
            }

            if (valueArrayType.IsGenericType)
            {
                Type elementType = valueArrayType.GetGenericArguments()[0];
                return elementType;
            }

            //TODO: Typed exception
            throw  new Exception("Can not find element type");
        }

        private HqlTreeNode BuildFromExpression(Expression expression, IHqlExpressionVisitor visitor)
        {
            //TODO: check if it's a valid expression for in clause, i.e. it selects only one column
            return visitor.Visit(expression).AsExpression();
        }

        private HqlTreeNode BuildFromArray(IEnumerable valueArray, HqlTreeBuilder treeBuilder, Type elementType)
        {
            Type enumUnderlyingType = elementType.IsEnum ? Enum.GetUnderlyingType(elementType) : null;
            IList<HqlTreeNode> variants = new List<HqlTreeNode>();

            foreach (object variant in valueArray)
            {
                object val = variant;

                if (elementType.IsEnum)
                    val = Convert.ChangeType(variant, enumUnderlyingType);

                HqlConstant hqlConstant = treeBuilder.Constant(val);
                variants.Add(hqlConstant);
            }

            return treeBuilder.ExpressionSubTreeHolder(variants);
        }
    }
}
