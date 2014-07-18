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
            IEnumerable<TModel> result = extended.GetAll<TModel>(extended.SessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao extended)
        {
            IQueryable<TModel> result = extended.Query<TModel>(extended.SessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao extended, TId id)
        {
            IQueryable<TModel> result = extended.GetById<TModel, TId>(extended.SessionManager.Current, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao extended, TId id)
        {
            IQueryable<TModel> queryable = extended.GetById<TModel, TId>(extended.SessionManager.Current, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IQueryable<TModel> GetByNamedQuery<TModel>(this IDao extended, string queryName, params object[] parameters)
        {
            IQueryable<TModel> result = extended.GetByNamedQuery<TModel>(extended.SessionManager.Current, queryName, parameters);
            return result;
        }

        public static IQueryable<TModel> GetByQuery<TModel>(this IDao extended, string queryString, params object[] parameters)
        {
            IQueryable<TModel> result = extended.GetByQuery<TModel>(extended.SessionManager.Current, queryString, parameters);
            return result;
        }

        public static TModel Insert<TModel>(this IDao extended, TModel entity)
        {
            TModel result = extended.Insert(extended.SessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            IEnumerable<TModel> result = extended.Insert(extended.SessionManager.Current, entities);
            return result;
        }

        public static TModel Update<TModel>(this IDao extended, TModel entity)
        {
            TModel result = extended.Update(extended.SessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            IEnumerable<TModel> result = extended.Update(extended.SessionManager.Current, entities);
            return result;
        }

        public static void Delete<TModel>(this IDao extended, TModel entity)
        {
            extended.Delete(extended.SessionManager.Current, entity);
        }

        public static void Delete<TModel>(this IDao extended, IEnumerable<TModel> entities)
        {
            extended.Delete(extended.SessionManager.Current, entities);
        }
    }
}
