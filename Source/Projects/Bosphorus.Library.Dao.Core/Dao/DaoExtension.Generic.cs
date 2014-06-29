using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class DaoExtension
    {
        public static IEnumerable<TModel> GetAll<TModel>(this IDao<TModel> extended)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.GetAll(session);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao<TModel> extended)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IQueryable<TModel> result = extended.Query(session);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao<TModel> extended, TId id)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IQueryable<TModel> result = extended.GetById(session, id);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao<TModel> extended, TId id)
        {
            IQueryable<TModel> queryable = extended.GetById(id);
            TModel result = queryable.Single();
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName, params object[] parameters)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.GetByNamedQuery(session, queryName, parameters);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString, params object[] parameters)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.GetByQuery(session, queryString, parameters);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel Insert<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.Insert(session, entity);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.Insert(session, entities);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel Update<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.Update(session, entity);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.Update(session, entities);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static void Delete<TModel>(this IDao<TModel> extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            extended.Delete(session, entity);
            sessionProvider.CloseSession(session);
        }

        public static void Delete<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            extended.Delete(session, entities);
            sessionProvider.CloseSession(session);
        }
    }
}
