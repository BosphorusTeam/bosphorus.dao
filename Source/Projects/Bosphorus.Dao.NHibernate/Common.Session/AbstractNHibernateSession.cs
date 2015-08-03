using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.NHibernate.Session
{
    public abstract class AbstractNHibernateSession<TNativeSession>: ISession
    {
        protected TNativeSession adapted;
        protected static readonly IDictionary<IsolationLevel, System.Data.IsolationLevel> isolationLevelDictionary;

        static AbstractNHibernateSession()
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

        protected AbstractNHibernateSession(TNativeSession adapted)
        {
            this.adapted = adapted;
        }

        public TNativeSession InnerSession
        {
            get { return adapted; }
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