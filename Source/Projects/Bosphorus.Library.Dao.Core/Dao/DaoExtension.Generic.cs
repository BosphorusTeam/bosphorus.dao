using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Dao.Core.Dao
{
    public static partial class DaoExtension
    {
        public static IEnumerable<TModel> GetAll<TModel>(this IDao<TModel> extended)
        {
            IEnumerable<TModel> result = extended.GetAll(extended.SessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> Query<TModel>(this IDao<TModel> extended)
        {
            IQueryable<TModel> result = extended.Query(extended.SessionManager.Current);
            return result;
        }

        public static IQueryable<TModel> GetById<TModel, TId>(this IDao<TModel> extended, TId id)
        {
            IQueryable<TModel> result = extended.GetById(extended.SessionManager.Current, id);
            return result;
        }

        public static TModel GetByIdSingle<TModel, TId>(this IDao<TModel> extended, TId id)
        {
            IQueryable<TModel> queryable = extended.GetById(extended.SessionManager.Current, id);
            TModel result = queryable.Single();
            return result;
        }

        public static IEnumerable<TModel> GetByNamedQuery<TModel>(this IDao<TModel> extended, string queryName, params object[] parameters)
        {
            IEnumerable<TModel> result = extended.GetByNamedQuery(extended.SessionManager.Current, queryName, parameters);
            return result;
        }

        public static IEnumerable<TModel> GetByQuery<TModel>(this IDao<TModel> extended, string queryString, params object[] parameters)
        {
            IEnumerable<TModel> result = extended.GetByQuery(extended.SessionManager.Current, queryString, parameters);
            return result;
        }

        public static TModel Insert<TModel>(this IDao<TModel> extended, TModel entity)
        {
            TModel result = extended.Insert(extended.SessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Insert<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            IEnumerable<TModel> result = extended.Insert(extended.SessionManager.Current, entities);
            return result;
        }

        public static TModel Update<TModel>(this IDao<TModel> extended, TModel entity)
        {
            TModel result = extended.Update(extended.SessionManager.Current, entity);
            return result;
        }

        public static IEnumerable<TModel> Update<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            IEnumerable<TModel> result = extended.Update(extended.SessionManager.Current, entities);
            return result;
        }

        public static void Delete<TModel>(this IDao<TModel> extended, TModel entity)
        {
            extended.Delete(extended.SessionManager.Current, entity);
        }

        public static void Delete<TModel>(this IDao<TModel> extended, IEnumerable<TModel> entities)
        {
            extended.Delete(extended.SessionManager.Current, entities);
        }
    }
}
