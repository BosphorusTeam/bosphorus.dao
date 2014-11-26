using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session.Manager;
using Castle.Core;

namespace Bosphorus.Dao.Core.Dao.Facade
{
    public static partial class DaoExtension
    {
        public static IEnumerable<TModel> GetAll<TModel>(this Dao extended)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IEnumerable<TModel> result = extended.GetAll<TModel>(sessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this Dao extended)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> result = extended.Query<TModel>(sessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this Dao extended, TId id)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetById<TModel, TId>(sessionManager.Current, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this Dao extended, TId id)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> queryable = extended.GetById<TModel, TId>(sessionManager.Current, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this Facade.Dao extended, string queryName)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(sessionManager.Current, queryName, Core.Dao.IDaoExtensions.emptyDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this Facade.Dao extended, string queryName, object argumentsAsAnonymousType)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(sessionManager.Current, queryName, parameterDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this Facade.Dao extended, string queryName, IDictionary parameterDictionary)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(sessionManager.Current, queryName, parameterDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this Facade.Dao extended, string queryString)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByQuery<TModel>(sessionManager.Current, queryString, Core.Dao.IDaoExtensions.emptyDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this Facade.Dao extended, string queryString, object argumentsAsAnonymousType)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IQueryable<TModel> result = extended.GetByQuery<TModel>(sessionManager.Current, queryString, parameterDictionary);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this Facade.Dao extended, string queryString, IDictionary parameterDictionary)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IQueryable<TModel> result = extended.GetByQuery<TModel>(sessionManager.Current, queryString, parameterDictionary);
            return result;
        }

        public static TModel Insert<TModel>(this Facade.Dao extended, TModel entity)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            TModel result = extended.Insert(sessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this Facade.Dao extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IEnumerable<TModel> result = extended.Insert(sessionManager.Current, entities);
            return result;
        }

        public static TModel Update<TModel>(this Facade.Dao extended, TModel entity)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            TModel result = extended.Update(sessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this Facade.Dao extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            IEnumerable<TModel> result = extended.Update(sessionManager.Current, entities);
            return result;
        }

        public static void Delete<TModel>(this Facade.Dao extended, TModel entity)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            extended.Delete(sessionManager.Current, entity);
        }

        public static void Delete<TModel>(this Facade.Dao extended, IEnumerable<TModel> entities)
        {
            ISessionManager sessionManager = Core.Dao.IDaoExtensions.GetSessionManager(extended);
            extended.Delete(sessionManager.Current, entities);
        }
    }
}
