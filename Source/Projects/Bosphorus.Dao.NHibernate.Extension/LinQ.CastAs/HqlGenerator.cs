using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.CastAs
{
    public class HqlGenerator : BaseHqlGeneratorForMethod
    {
        public HqlGenerator()
        {
            this.SupportedMethods = new[] { ReflectionHelper.GetMethodDefinition(() => ObjectExtensions.CastAs<Object>(null)) };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            HqlExpression argument0Expression = visitor.Visit(arguments[0]).AsExpression();
            HqlTreeNode result = treeBuilder.Cast(argument0Expression, method.ReturnType);
            return result;
        }
    }
}