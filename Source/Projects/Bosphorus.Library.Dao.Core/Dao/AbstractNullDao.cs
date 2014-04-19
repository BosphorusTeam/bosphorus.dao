using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;

namespace Bosphorus.Dao.Core.Dao
{
    public abstract class AbstractNullDao<TModel> : AbstractDao<TModel>
    {
        protected AbstractNullDao()
        {
            //Session = NullSession.Instance;
        }

        public override IEnumerable<TModel> GetAll(ISession currentSession)
        {
            return new List<TModel>();
        }

        public override IQueryable<TModel> Query(ISession currentSession)
        {
            return new List<TModel>().AsQueryable();
        }

        public override TModel GetById<TId>(ISession currentSession, TId id)
        {
            return default(TModel);
        }

        public override IList<TModel> GetByCriteria(ISession currentSession, params object[] criterions)
        {
            return new List<TModel>();
        }

        public override IEnumerable<TModel> GetByNamedQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            return new List<TModel>();
        }

        public override IList<TReturnType> GetByNamedQuery<TReturnType>(ISession currentSession, string queryName, params object[] parameters)
        {
            return new List<TReturnType>();
        }

        public override IEnumerable<TModel> GetByQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            return new List<TModel>();
        }

        public override IList<TReturnType> GetByQuery<TReturnType>(ISession currentSession, string queryName, params object[] parameters)
        {
            return new List<TReturnType>();
        }

        public override TModel LoadById<TId>(ISession currentSession, TId id)
        {
            return default(TModel);
        }

        public override TModel LoadById(ISession currentSession, object id)
        {
            return default(TModel);
        }

        public override TModel Save(ISession currentSession, TModel entity)
        {
            return entity;
        }

        public override IEnumerable<TModel> Save(ISession currentSession, IEnumerable<TModel> entities)
        {
            return entities;
        }

        public override TModel SaveOrUpdate(ISession currentSession, TModel entity)
        {
            return entity;
        }

        public override IEnumerable<TModel> SaveOrUpdate(ISession currentSession, IEnumerable<TModel> entities)
        {
            return entities;
        }

        public override TModel Update(ISession currentSession, TModel entity)
        {
            return entity;
        }

        public override IEnumerable<TModel> Update(ISession currentSession, IEnumerable<TModel> entities)
        {
            return entities;
        }

        public override void Delete(ISession currentSession, TModel entity)
        {
        }

        public override void Delete(ISession currentSession, IEnumerable<TModel> entities)
        {
        }
    }
}
