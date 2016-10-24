using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Common.Api.Container;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Castle.Core;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Dao
{
    public static class DaoExtensions
    {
        private static IWindsorContainer container;
        private static readonly IDictionary emptyDictionary;
        private static readonly Lazy<ISessionProvider> sessionProvider;
        private static readonly Lazy<SessionDaoRegistry> sessionDaoRegistry;

        public class Installer : IBosphorusInstaller
        {
            public void Install(IWindsorContainer instance, IConfigurationStore store)
            {
                container = instance;
            }
        }

        static DaoExtensions()
        {
            sessionProvider = new Lazy<ISessionProvider>(() => container.Resolve<ISessionProvider>());
            sessionDaoRegistry = new Lazy<SessionDaoRegistry>(() => container.Resolve<SessionDaoRegistry>());
            emptyDictionary = new Hashtable();
        }

        private static ISession GetSession<TModel>(IDao<TModel> dao, string aliasName = null)
        {
            Type daoType = dao.GetType();
            Type daoGenericType = daoType.GetGenericTypeDefinition();
            Type sessionType = sessionDaoRegistry.Value.GetSessionType(daoGenericType);
            ISession session = sessionProvider.Value.Current(sessionType);
            return session;
        }

        public static IQueryable<TModel> GetAll<TModel>(this IDao<TModel> extended)
        {
            ISession session = GetSession(extended);
            IQueryable<TModel> result = extended.GetAll(session);
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

        public static IEnumerable<TModel> Insert<TModel>(this IDao<TModel> extended, IList<TModel> entities)
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

        public static IEnumerable<TModel> Update<TModel>(this IDao<TModel> extended, IList<TModel> entities)
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

        public static void Delete<TModel>(this IDao<TModel> extended, IList<TModel> entities)
        {
            ISession session = GetSession(extended);
            extended.Delete(session, entities);
        }
    }
}
