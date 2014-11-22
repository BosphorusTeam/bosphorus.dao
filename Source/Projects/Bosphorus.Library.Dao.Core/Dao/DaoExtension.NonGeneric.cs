using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Castle.Core;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class DaoExtension
    {
        public static IEnumerable<TModel> GetAll<TModel>(this IDao extended)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetAll<TModel>(sessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao extended)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.Query<TModel>(sessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao extended, TId id)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetById<TModel, TId>(sessionManager.Current, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao extended, TId id)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> queryable = extended.GetById<TModel, TId>(sessionManager.Current, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this IDao extended, string queryName)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(sessionManager.Current, queryName, emptyDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this IDao extended, string queryName, object argumentsAsAnonymousType)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(sessionManager.Current, queryName, parameterDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this IDao extended, string queryName, IDictionary parameterDictionary)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(sessionManager.Current, queryName, parameterDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this IDao extended, string queryString)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByQuery<TModel>(sessionManager.Current, queryString, emptyDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this IDao extended, string queryString, object argumentsAsAnonymousType)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IQueryable<TModel> result = extended.GetByQuery<TModel>(sessionManager.Current, queryString, parameterDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this IDao extended, string queryString, IDictionary parameterDictionary)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByQuery<TModel>(sessionManager.Current, queryString, parameterDictionary);
            return result;
        }

        public static TModel Insert<TModel>(this IDao extended, TModel entity)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            TModel result = extended.Insert(sessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.Insert(sessionManager.Current, entities);
            return result;
        }

        public static TModel Update<TModel>(this IDao extended, TModel entity)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            TModel result = extended.Update(sessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            IEnumerable<TModel> result = extended.Update(sessionManager.Current, entities);
            return result;
        }

        public static void Delete<TModel>(this IDao extended, TModel entity)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            extended.Delete(sessionManager.Current, entity);
        }

        public static void Delete<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = GetSessionManager(extended);
            extended.Delete(sessionManager.Current, entities);
        }
    }
}
