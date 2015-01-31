using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Lucene.Net.Linq;
using Bosphorus.Dao.Lucene.Session;

namespace Bosphorus.Dao.Lucene.Dao
{
    public class LuceneDao<TModel> : ILuceneDao<TModel>
    {
        private ISession<TModel> GetNativeSession(ISession currentSession)
        {
            return ((LuceneSession<TModel>)currentSession).InnerSession;
        }

        public IQueryable<TModel> GetAll(ISession currentSession)
        {
            IQueryable<TModel> result = Query(currentSession);
            return result;
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

        public TModel Insert(ISession currentSession, TModel model)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Add(model);
            nativeSession.Commit();
            return model;
        }

        public IEnumerable<TModel> Insert(ISession currentSession, IEnumerable<TModel> models)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Add(models.ToArray());
            nativeSession.Commit();
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

        public void Delete(ISession currentSession, TModel model)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Delete(model);
            nativeSession.Commit();
        }

        public void Delete(ISession currentSession, IEnumerable<TModel> models)
        {
            ISession<TModel> nativeSession = GetNativeSession(currentSession);
            nativeSession.Delete(models.ToArray());
            nativeSession.Commit();
        }
    }
}