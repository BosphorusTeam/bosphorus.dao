using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Common.Api.Container;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Castle.Core;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Dao
{
    public static class GenericDaoExtensions
    {
        private static IWindsorContainer container;
        private static readonly IDictionary emptyDictionary;
        private static readonly Lazy<ISessionProvider> sessionProvider;
        private static readonly Lazy<SessionDaoRegistry> sessionDaoRegistry;

        public class Installer: IBosphorusInstaller
        {
            public void Install(IWindsorContainer instance, IConfigurationStore store)
            {
                container = instance;
            }
        }

        static GenericDaoExtensions()
        {
            emptyDictionary = new Hashtable();
            sessionProvider = new Lazy<ISessionProvider>(() => container.Resolve<ISessionProvider>());
            sessionDaoRegistry = new Lazy<SessionDaoRegistry>(() => container.Resolve<SessionDaoRegistry>());
        }

        private static ISession GetSession<TModel>(string aliasName = null)
        {
            IDao<TModel> dao = container.Resolve<IDao<TModel>>();
            Type daoType = dao.GetType();
            Type daoGenericType = daoType.GetGenericTypeDefinition();
            Type sessionType = sessionDaoRegistry.Value.GetSessionType(daoGenericType);
            ISession session = sessionProvider.Value.Current(sessionType);
            return session;
        }

        public static IQueryable<TModel> GetAll<TModel>(this GenericDao extended)
        {
            ISession session = GetSession<TModel>();
            IQueryable<TModel> result = extended.GetAll<TModel>(session);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this GenericDao extended) 
        {
            ISession session = GetSession<TModel>();
            IQueryable<TModel> result = extended.Query<TModel>(session);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this GenericDao extended, TId id) 
        {
            ISession session = GetSession<TModel>();
            IQueryable<TModel> result = extended.GetById<TModel, TId>(session, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this GenericDao extended, TId id) 
        {
            ISession session = GetSession<TModel>();
            IQueryable<TModel> queryable = extended.GetById<TModel, TId>(session, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this GenericDao extended, string queryName) 
            
        {
            ISession session = GetSession<TModel>();
            IEnumerable<TModel> result = extended.GetByNamedQuery<TModel>(session, queryName, emptyDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this GenericDao extended, string queryName, object argumentsAsAnonymousType) 
            
        {
            ISession session = GetSession<TModel>();
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IEnumerable<TModel> result = extended.GetByNamedQuery<TModel>(session, queryName, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this GenericDao extended, string queryName, IDictionary parameterDictionary) 
            
        {
            ISession session = GetSession<TModel>();
            IEnumerable<TModel> result = extended.GetByNamedQuery<TModel>(session, queryName, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this GenericDao extended, string queryString) 
        {
            ISession session = GetSession<TModel>();
            IEnumerable<TModel> result = extended.GetByQuery<TModel>(session, queryString, emptyDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this GenericDao extended, string queryString, object argumentsAsAnonymousType) 
        {
            ISession session = GetSession<TModel>();
            IDictionary parameterDictionary = new ReflectionBasedDictionaryAdapter(argumentsAsAnonymousType);
            IEnumerable<TModel> result = extended.GetByQuery<TModel>(session, queryString, parameterDictionary);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this GenericDao extended, string queryString, IDictionary parameterDictionary) 
        {
            ISession session = GetSession<TModel>();
            IEnumerable<TModel> result = extended.GetByQuery<TModel>(session, queryString, parameterDictionary);
            return result;
        }

        public static TModel Insert<TModel>(this GenericDao extended, TModel entity) 
        {
            ISession session = GetSession<TModel>();
            TModel result = extended.Insert(session, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this GenericDao extended, IEnumerable<TModel> entities) 
        {
            ISession session = GetSession<TModel>();
            IEnumerable<TModel> result = extended.Insert(session, entities);
            return result;
        }

        public static TModel Update<TModel>(this GenericDao extended, TModel entity) 
        {
            ISession session = GetSession<TModel>();
            TModel result = extended.Update(session, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this GenericDao extended, IEnumerable<TModel> entities) 
        {
            ISession session = GetSession<TModel>();
            IEnumerable<TModel> result = extended.Update(session, entities);
            return result;
        }

        public static void Delete<TModel>(this GenericDao extended, TModel entity)
        {
            ISession session = GetSession<TModel>();
            extended.Delete(session, entity);
        }

        public static void Delete<TModel>(this GenericDao extended, IEnumerable<TModel> entities)
        {
            ISession session = GetSession<TModel>();
            extended.Delete(session, entities);
        }
    }
}
