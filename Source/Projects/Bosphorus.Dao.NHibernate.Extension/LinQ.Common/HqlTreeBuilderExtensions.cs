using System;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Hql.Ast.ANTLR.Tree;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.Common
{
    public static class HqlTreeBuilderExtensions
    {
        private readonly static FieldInfo factoryField;

        static  HqlTreeBuilderExtensions()
        {
            Type hqlTreeBuilderType = typeof (HqlTreeBuilder);
            factoryField = hqlTreeBuilderType.GetField("_factory", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static IASTFactory GetFactory(this HqlTreeBuilder treeBuilder)
        {
            IASTFactory result = (IASTFactory)factoryField.GetValue(treeBuilder);
            return result;
        }

        public static HqlAnyValueConstant AnyValueConstant(this HqlTreeBuilder treeBuilder, string value, params HqlTreeNode[] children)
        {
            IASTFactory factory = treeBuilder.GetFactory();
            return new HqlAnyValueConstant(factory, value, children);
        }
    }
}
