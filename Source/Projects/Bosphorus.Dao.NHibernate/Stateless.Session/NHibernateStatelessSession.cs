using Bosphorus.Dao.Core.Transaction;
using Bosphorus.Dao.NHibernate.Common.Session;
using Bosphorus.Dao.NHibernate.Transaction;
using NHibernate.Impl;

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
            System.Data.IsolationLevel adaptedIsolationLevel = IsolationLevelDictionary[isolationLevel];
            global::NHibernate.ITransaction adaptedTransaction = adapted.BeginTransaction(adaptedIsolationLevel);
            return new NHibernateStatelessTransaction(adaptedTransaction);
        }

        public override void Clear()
        {
        }

        public override void Flush()
        {
            ((StatelessSessionImpl)adapted).ManagedFlush();
        }
    }
}
