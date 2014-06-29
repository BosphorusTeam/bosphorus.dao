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

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.Equals
{
    //TODO: Not working properly
    //http://www.primordialcode.com/blog/post/nhibernate-3-extending-linq-provider-fix-notsupportedexception
    public class HqlGenerator : BaseHqlGeneratorForMethod
    {
        public HqlGenerator()
        {
            // the methods call are used only to get info about the signature, the actual parameter is just ignored
            SupportedMethods = new[] {
                ReflectionHelper.GetMethodDefinition<Byte>(x => x.Equals((Byte)0)),
                ReflectionHelper.GetMethodDefinition<SByte>(x => x.Equals((SByte)0)),
                ReflectionHelper.GetMethodDefinition<Int16>(x => x.Equals((Int16)0)),
                ReflectionHelper.GetMethodDefinition<Int32>(x => x.Equals((Int32)0)),
                ReflectionHelper.GetMethodDefinition<Int64>(x => x.Equals((Int64)0)),
                ReflectionHelper.GetMethodDefinition<UInt16>(x => x.Equals((UInt16)0)),
                ReflectionHelper.GetMethodDefinition<UInt32>(x => x.Equals((UInt32)0)),
                ReflectionHelper.GetMethodDefinition<UInt64>(x => x.Equals((UInt64)0)),
                ReflectionHelper.GetMethodDefinition<Single>(x => x.Equals((Single)0)),
                ReflectionHelper.GetMethodDefinition<Double>(x => x.Equals((Double)0)),
                ReflectionHelper.GetMethodDefinition<Boolean>(x => x.Equals(true)),
                ReflectionHelper.GetMethodDefinition<Char>(x => x.Equals((Char)0)),
                ReflectionHelper.GetMethodDefinition<Decimal>(x => x.Equals((Decimal)0)),
                ReflectionHelper.GetMethodDefinition<Guid>(x => x.Equals(Guid.Empty)),
            };
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            HqlExpression targetExpression = visitor.Visit(targetObject).AsExpression();
            HqlExpression argument0Expression = visitor.Visit(arguments[0]).AsExpression();
            HqlEquality result = treeBuilder.Equality(targetExpression, argument0Expression);
            return result;
        }
    }

}
