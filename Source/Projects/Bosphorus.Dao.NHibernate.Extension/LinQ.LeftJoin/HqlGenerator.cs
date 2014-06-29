using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Common;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.LeftJoin
{
    //TODO: Complete it..
    public class HqlGenerator : BaseHqlGeneratorForMethod
    {
        public HqlGenerator()
        {
            SupportedMethods = new[] { ReflectionHelper.GetMethodDefinition(() => ObjectExtensions.OraclePlus<object>(null))};
        }

        public override HqlTreeNode BuildHql(MethodInfo method, Expression targetObject, ReadOnlyCollection<Expression> arguments, HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            /*
            HqlDot hqlDot = (HqlDot)visitor.Visit(arguments[0]).AsExpression();
            List<HqlTreeNode> hqlTreeNodes = hqlDot.Children.ToList();

            FieldInfo fieldInfo = typeof(HqlTreeNode).GetField("_node", BindingFlags.NonPublic | BindingFlags.Instance);

            HqlIdent node1 = (HqlIdent)hqlTreeNodes[0];
            IASTNode tableNode = (IASTNode)fieldInfo.GetValue(node1);
            string tableText = tableNode.Text;

            HqlIdent node2 = (HqlIdent)hqlTreeNodes[1];
            IASTNode columnNode = (IASTNode)fieldInfo.GetValue(node2);
            string columnText = columnNode.Text;

            string format = string.Format("{0}.{1} (+)", tableText, columnText);

            //return treeBuilder.AnyValueConstant(format);
            return treeBuilder.AnyValueConstant("customer1_.ID (+)");
            */


            HqlAnyValueConstant expression0 = treeBuilder.AnyValueConstant("+");
            HqlExpression expression1 = visitor.Visit(arguments[0]).AsExpression();

            List<HqlExpression> expressions = new List<HqlExpression>();
            expressions.Add(expression0);
            expressions.Add(expression1);
            return treeBuilder.BooleanMethodCall("", expressions);



            //treeBuilder.Equality();
            //HqlMethodCall leftSign = treeBuilder.MethodCall("", treeBuilder.Plus());

            /*
            return expression2;

            HqlDot dot = (HqlDot) expression2;
            //return treeBuilder.AnyValueConstant(" ", expression1, expression2);
            return expression1;

            /*
            return expression2;
            */
            //return leftSign;
            //return treeBuilder.Space(leftSign, );
        }
    }
}
