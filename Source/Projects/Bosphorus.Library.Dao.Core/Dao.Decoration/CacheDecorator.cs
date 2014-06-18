using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Session;

namespace Bosphorus.Dao.Core.Dao.Decoration
{
    class CacheDecorator<TModel>: AbstractDaoDecorator<TModel>
    {
        private readonly IDao<TModel> decorated;
        private readonly IList<TModel> cache;

        public CacheDecorator(IDao<TModel> decorated)
            : base(decorated)
        {
            this.decorated = decorated;
            this.cache = decorated.GetAll().ToList();
        }

        public override IEnumerable<TModel> GetAll(ISession currentSession)
        {
            return cache;
        }

        public override IQueryable<TModel> Query(ISession currentSession)
        {
            return cache.AsQueryable();
        }
    }
}
