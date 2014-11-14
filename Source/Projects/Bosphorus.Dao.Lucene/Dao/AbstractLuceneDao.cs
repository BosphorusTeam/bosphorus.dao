using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Lucene.Session;
using Bosphorus.Dao.Lucene.Session.Manager;
using Bosphorus.Dao.Lucene.Session.Manager.Factory;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Dao
{
    public abstract class AbstractLuceneDao<TModel>
    {
        private readonly ISessionManager sessionManager;

        protected AbstractLuceneDao(ILuceneSessionManagerFactory sessionManagerFactory, string sessionAlias)
        {
            sessionManager = sessionManagerFactory.Build(typeof(TModel));
        }

        public ISessionManager SessionManager
        {
            get { return sessionManager; }
        }

        protected ISession<TModel> GetNativeSession(ISession currentSession)
        {
            return ((LuceneSession<TModel>)currentSession).InnerSession;
        }

        public IQueryable<TModel> GetAll(ISession currentSession)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> Query(ISession currentSession)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            IQueryable<TModel> queryable = nativeSession.Query();
            return queryable;
        }

        public IQueryable<TModel> GetById<TId>(ISession currentSession, TId id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> GetByNamedQuery(ISession currentSession, string queryName, IDictionary parameterDictionary)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TModel> GetByQuery(ISession currentSession, string queryString, IDictionary parameterDictionary)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Insert(ISession currentSession, TModel model)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Add(model);
            return model;
        }

        public virtual IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Add(models.ToArray());
            return models;
        }

        public TModel Update(ISession currentSession, TModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> models)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(ISession currentSession, TModel model)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Delete(model);
        }

        public virtual void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Delete(models.ToArray());
        }
    }
}
