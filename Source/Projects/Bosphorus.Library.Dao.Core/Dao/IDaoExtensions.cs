using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Castle.Core;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class IDaoExtensions
    {
        public readonly static IDictionary emptyDictionary;
        private readonly static ISessionManager defaultSessionManager;

        static IDaoExtensions()
        {
            emptyDictionary = new Hashtable();
            var creationContext = new {SessionAlias = "Default"};
            defaultSessionManager = ServiceRegistry.Get<ISessionManager>(creationContext);
        }

        public static IEnumerable<TModel> GetAll<TModel>(this IDao<TModel> extended)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetAll(sessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao<TModel> extended)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.Query(sessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao<TModel> extended, TId id)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetById(sessionManager.Current, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao<TModel> extended, TId id)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> queryable = extended.GetById(sessionManager.Current, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetByNamedQuery(sessionManager.Current, queryName, emptyDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName, object argumentsAsAnonymousType)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IEnumerable<TModel> result = extended.GetByNamedQuery(sessionManager.Current, queryName, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName, IDictionary parameterDictionary)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetByNamedQuery(sessionManager.Current, queryName, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetByQuery(sessionManager.Current, queryString, emptyDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString, object argumentsAsAnonymousType)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IEnumerable<TModel> result = extended.GetByQuery(sessionManager.Current, queryString, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString, IDictionary parameterDictionary)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetByQuery(sessionManager.Current, queryString, parameterDictionary);
            return result;
        }

        public static TModel Insert<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            TModel result = extended.Insert(sessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.Insert(sessionManager.Current, entities);
            return result;
        }

        public static TModel Update<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            TModel result = extended.Update(sessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.Update(sessionManager.Current, entities);
            return result;
        }

        public static void Delete<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            extended.Delete(sessionManager.Current, entity);
        }

        public static void Delete<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            extended.Delete(sessionManager.Current, entities);
        }

        internal static ISessionManager GetSessionManager(object extended)
        {
            return defaultSessionManager;
        }
    }
}
