using Bosphorus.Dao.Core.Transaction;
using Bosphorus.Dao.NHibernate.Common.Session;
using Bosphorus.Dao.NHibernate.Transaction;

namespace Bosphorus.Dao.NHibernate.Stateless.Session
{
    public class NHibernateStatelessSession : AbstractNHibernateSession<global::NHibernate.IStatelessSession>
    {
        public NHibernateStatelessSession(global::NHibernate.IStatelessSession adapted) 
            : base(adapted)
        {
        }

        public override ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            System.Data.IsolationLevel adaptedIsolationLevel = isolationLevelDictionary[isolationLevel];
            global::NHibernate.ITransaction adaptedTransaction = adapted.BeginTransaction(adaptedIsolationLevel);
            return new NHibernateStatelessTransaction(adaptedTransaction);
        }

        protected override void DisposeManagedObjects()
        {
            adapted.Close();
            adapted = null;
        }
    }
}
