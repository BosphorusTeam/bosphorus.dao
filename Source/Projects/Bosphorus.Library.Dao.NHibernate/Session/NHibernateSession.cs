using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Transaction;
using Bosphorus.Dao.NHibernate.Transaction;

namespace Bosphorus.Dao.NHibernate.Session
{
    public class NHibernateSession: ISession
    {
        private global::NHibernate.ISession adapted;
        private static readonly IDictionary<IsolationLevel, System.Data.IsolationLevel> isolationLevelDictionary;

        static NHibernateSession()
        {
            isolationLevelDictionary = new Dictionary<IsolationLevel, System.Data.IsolationLevel>();
            isolationLevelDictionary.Add(IsolationLevel.Chaos, System.Data.IsolationLevel.Chaos);
            isolationLevelDictionary.Add(IsolationLevel.ReadCommitted, System.Data.IsolationLevel.ReadCommitted);
            isolationLevelDictionary.Add(IsolationLevel.ReadUncommitted, System.Data.IsolationLevel.ReadUncommitted);
            isolationLevelDictionary.Add(IsolationLevel.RepeatableRead, System.Data.IsolationLevel.RepeatableRead);
            isolationLevelDictionary.Add(IsolationLevel.Serializable, System.Data.IsolationLevel.Serializable);
            isolationLevelDictionary.Add(IsolationLevel.Snapshot, System.Data.IsolationLevel.Snapshot);
            isolationLevelDictionary.Add(IsolationLevel.Unspecified, System.Data.IsolationLevel.Unspecified);
        }

        public NHibernateSession(global::NHibernate.ISession adapted)
        {
            this.adapted = adapted;
        }

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            System.Data.IsolationLevel adaptedIsolationLevel = isolationLevelDictionary[isolationLevel];
            global::NHibernate.ITransaction adaptedTransaction = adapted.BeginTransaction(adaptedIsolationLevel);
            return new NHibernateTransaction(adaptedTransaction, adapted);
        }

        public global::NHibernate.ISession InnerSession
        {
            get { return adapted; }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                adapted.Flush();
                //adapted.Disconnect();
                adapted = null;
                GC.SuppressFinalize(this);
            }
        }

        ~NHibernateSession()
        {
            Dispose(false);
        }
    }
}
