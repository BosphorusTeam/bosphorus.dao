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

        public static TModel GetById<TId, TModel>(this IDao extended, TId id)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.GetById<TModel, TId>(session, id);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao extended, string queryName, params object[] parameters)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.GetByNamedQuery<TModel>(session, queryName, parameters);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao extended, string queryString, params object[] parameters)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.GetByQuery<TModel>(session, queryString, parameters);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel LoadById<TId, TModel>(this IDao extended, TId id)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.LoadById<TModel, TId>(session, id);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel LoadById<TModel>(this IDao extended, object id)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.LoadById<TModel, object>(session, id);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static TModel Save<TModel>(this IDao extended, TModel entity)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            TModel result = extended.Save(session, entity);
            sessionProvider.CloseSession(session);
            return result;
        }

        public static IEnumerable<TModel> Save<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            ISessionProvider sessionProvider = extended.SessionProvider;
            ISession session = sessionProvider.OpenSession();
            IEnumerable<TModel> result = extended.Save(session, entities);
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
