using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Manager;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory.Decoration
{
    public class CacheDecorator: ILuceneSessionManagerFactory
    {
        private readonly ILuceneSessionManagerFactory decorated;
        private readonly IDictionary<Type, ISessionManager> cache;

        public CacheDecorator(ILuceneSessionManagerFactory decorated)
        {
            this.decorated = decorated;
            this.cache = new Dictionary<Type, ISessionManager>();
        }

        public ISessionManager Build(Type type)
        {
            if (cache.ContainsKey(type))
            {
                ISessionManager sessionManager = cache[type];
                return sessionManager;
            }

            ISessionManager newSessionManager = decorated.Build(type);
            cache[type] = newSessionManager;
            return newSessionManager;
        }
    }
}
