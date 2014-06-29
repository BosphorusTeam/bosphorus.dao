using NHibernate.Hql.Ast;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Hql.Ast.ANTLR.Tree;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ.Common
{
    public class HqlAnyValueConstant : HqlExpression
    {
        public HqlAnyValueConstant(IASTFactory factory, string value, params HqlTreeNode[] children)
            : base(HqlSqlWalker.QUOTED_String, value, factory, children)
        {
        }
    }
}
