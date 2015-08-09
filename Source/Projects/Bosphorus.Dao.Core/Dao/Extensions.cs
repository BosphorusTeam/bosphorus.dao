using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;
using Castle.Core;

namespace Bosphorus.Dao.Core.Dao
{
    public static class Extensions
    {
        private readonly static ISessionProvider sessionProvider;
        private readonly static IDictionary emptyDictionary;

        static Extensions()
        {
            sessionProvider = IoC.staticContainer.Resolve<ISessionProvider>();
            emptyDictionary = new Hashtable();
        }

        private static ISession GetSession<TModel>(IDao<TModel> dao = null, string aliasName = null)
        {
            ISession session = sessionProvider.Current();
            return session;
        }

        public static IEnumerable<TModel> GetAll<TModel>(this IDao<TModel> extended)
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.GetAll(session);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao<TModel> extended) 
        {
            ISession session = GetSession(extended);
            IQueryable<TModel> result = extended.Query(session);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao<TModel> extended, TId id) 
        {
            ISession session = GetSession(extended);
            IQueryable<TModel> result = extended.GetById(session, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao<TModel> extended, TId id) 
            
        {
            ISession session = GetSession(extended);
            IQueryable<TModel> queryable = extended.GetById(session, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName) 
            
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.GetByNamedQuery(session, queryName, emptyDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName, object argumentsAsAnonymousType) 
            
        {
            ISession session = GetSession(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IEnumerable<TModel> result = extended.GetByNamedQuery(session, queryName, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName, IDictionary parameterDictionary) 
            
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.GetByNamedQuery(session, queryName, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString) 
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.GetByQuery(session, queryString, emptyDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString, object argumentsAsAnonymousType) 
        {
            ISession session = GetSession(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IEnumerable<TModel> result = extended.GetByQuery(session, queryString, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString, IDictionary parameterDictionary) 
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.GetByQuery(session, queryString, parameterDictionary);
            return result;
        }

        public static TModel Insert<TModel>(this IDao<TModel> extended, TModel entity) 
        {
            ISession session = GetSession(extended);
            TModel result = extended.Insert(session, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities) 
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.Insert(session, entities);
            return result;
        }

        public static TModel Update<TModel>(this IDao<TModel> extended, TModel entity) 
        {
            ISession session = GetSession(extended);
            TModel result = extended.Update(session, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities) 
        {
            ISession session = GetSession(extended);
            IEnumerable<TModel> result = extended.Update(session, entities);
            return result;
        }

        public static void Delete<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISession session = GetSession(extended);
            extended.Delete(session, entity);
        }

        public static void Delete<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISession session = GetSession(extended);
            extended.Delete(session, entities);
        }
    }
}
