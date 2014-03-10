using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Dao.Decoration
{
    class CacheDecorator<TModel>: IDao<TModel>
    {
        private readonly IDao<TModel> decorated;
        private readonly IList<TModel> cache;

        public CacheDecorator(IDao<TModel> decorated)
        {
            this.decorated = decorated;
            this.cache = decorated.GetAll().ToList();
        }

        public ISessionProvider SessionProvider
        {
            get { return decorated.SessionProvider; }
        }

        public IEnumerable<TModel> GetAll(ISession currentSession)
        {
            return cache;
        }

        public IQueryable<TModel> Query(ISession currentSession)
        {
            return cache.AsQueryable();
        }

        public TModel GetById<TId>(ISession currentSession, TId id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetByNamedQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetByQuery(ISession currentSession, string queryString, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public TModel LoadById<TId>(ISession currentSession, TId id)
        {
            throw new NotImplementedException();
        }

        public TModel Save(ISession currentSession, TModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> Save(ISession currentSession, IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISession currentSession, TModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISession currentSession, IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
