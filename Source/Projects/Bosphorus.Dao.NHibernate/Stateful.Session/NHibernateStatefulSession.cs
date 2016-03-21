using Bosphorus.Dao.Core.Transaction;
using Bosphorus.Dao.NHibernate.Common.Session;
using Bosphorus.Dao.NHibernate.Transaction;

namespace Bosphorus.Dao.NHibernate.Stateful.Session
{
    public class NHibernateStatefulSession : AbstractNHibernateSession<global::NHibernate.ISession>
    {
        public NHibernateStatefulSession(global::NHibernate.ISession adapted) 
            : base(adapted)
        {
        }

        public override ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            System.Data.IsolationLevel adaptedIsolationLevel = IsolationLevelDictionary[isolationLevel];
            global::NHibernate.ITransaction adaptedTransaction = adapted.BeginTransaction(adaptedIsolationLevel);
            NHibernateStatefulTransaction transaction = new NHibernateStatefulTransaction(adaptedTransaction, adapted);
            return transaction;
        }

        public override void Clear()
        {
            adapted.Clear();
        }

        public override void Flush()
        {
            adapted.Flush();
        }
    }
}
