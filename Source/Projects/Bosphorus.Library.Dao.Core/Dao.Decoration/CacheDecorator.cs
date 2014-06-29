using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;

namespace Bosphorus.Dao.Core.Dao.Decoration
{
    class CacheDecorator<TModel>: AbstractDaoDecorator<TModel>
    {
        private readonly IQueryable<TModel> cache;

        public CacheDecorator(IDao<TModel> decorated)
            : base(decorated)
        {
            this.cache = decorated.GetAll().ToList().AsQueryable();
        }

        public override IQueryable<TModel> GetAll(ISession currentSession)
        {
            return cache;
        }

        public override IQueryable<TModel> Query(ISession currentSession)
        {
            return cache;
        }
    }
}
