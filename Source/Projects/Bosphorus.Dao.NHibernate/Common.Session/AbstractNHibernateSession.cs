using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.NHibernate.Common.Session
{
    public abstract class AbstractNHibernateSession<TNativeSession>: ISession
    {
        protected TNativeSession adapted;
        protected static readonly IDictionary<IsolationLevel, System.Data.IsolationLevel> IsolationLevelDictionary;

        static AbstractNHibernateSession()
        {
            IsolationLevelDictionary = new Dictionary<IsolationLevel, System.Data.IsolationLevel>();
            IsolationLevelDictionary.Add(IsolationLevel.Chaos, System.Data.IsolationLevel.Chaos);
            IsolationLevelDictionary.Add(IsolationLevel.ReadCommitted, System.Data.IsolationLevel.ReadCommitted);
            IsolationLevelDictionary.Add(IsolationLevel.ReadUncommitted, System.Data.IsolationLevel.ReadUncommitted);
            IsolationLevelDictionary.Add(IsolationLevel.RepeatableRead, System.Data.IsolationLevel.RepeatableRead);
            IsolationLevelDictionary.Add(IsolationLevel.Serializable, System.Data.IsolationLevel.Serializable);
            IsolationLevelDictionary.Add(IsolationLevel.Snapshot, System.Data.IsolationLevel.Snapshot);
            IsolationLevelDictionary.Add(IsolationLevel.Unspecified, System.Data.IsolationLevel.Unspecified);
        }

        public object NativeSession => adapted;

        protected AbstractNHibernateSession(TNativeSession adapted)
        {
            this.adapted = adapted;
        }
        
        public abstract ITransaction NewTransaction(IsolationLevel isolationLevel);
        public void Dispose()
        {
            DisposeManagedObjects();
            GC.SuppressFinalize(this);
        }

        protected abstract void DisposeManagedObjects();
    }
}