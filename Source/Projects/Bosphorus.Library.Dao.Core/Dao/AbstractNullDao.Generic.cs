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

        public override IEnumerable<TModel> GetByNamedQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            return new List<TModel>();
        }

        public override IEnumerable<TModel> GetByQuery(ISession currentSession, string queryName, params object[] parameters)
        {
            return new List<TModel>();
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
