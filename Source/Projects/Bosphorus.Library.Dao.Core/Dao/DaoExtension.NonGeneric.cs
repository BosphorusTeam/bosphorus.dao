using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class DaoExtension
    {
        public static IEnumerable<TModel> GetAll<TModel>(this IDao extended)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.GetAll<TModel>(session);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao extended)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IQueryable<TModel> result = extended.Query<TModel>(session);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao extended, TId id)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IQueryable<TModel> result = extended.GetById<TModel, TId>(session, id);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao extended, TId id)
        {
            IQueryable<TModel> queryable = extended.GetById<TModel, TId>(id);
            TModel result = queryable.Single();
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this IDao extended, string queryName, params object[] parameters)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(session, queryName, parameters);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this IDao extended, string queryString, params object[] parameters)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IQueryable<TModel> result = extended.GetByQuery<TModel>(session, queryString, parameters);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel Insert<TModel>(this IDao extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.Insert(session, entity);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.Insert(session, entities);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel Update<TModel>(this IDao extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.Update(session, entity);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.Update(session, entities);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static void Delete<TModel>(this IDao extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            extended.Delete(session, entity);
            sessionProvider.CloseSession(session);
        }

        public static void Delete<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            extended.Delete(session, entities);
            sessionProvider.CloseSession(session);
        }
    }
}
