using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Manager;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory.Decoration
{
    public class CacheDecorator: ILuceneSessionManagerFactory
    {
        private readonly ILuceneSessionManagerFactory decorated;
        private readonly IDictionary<Tuple<string, Type>, ISessionManager> cache;

        public CacheDecorator(ILuceneSessionManagerFactory decorated)
        {
            this.decorated = decorated;
            this.cache = new Dictionary<Tuple<string, Type>, ISessionManager>();
        }

        public ISessionManager Build(string sessionAlias, Type type)
        {
            Tuple<string, Type> key = new Tuple<string, Type>(sessionAlias, type);
            if (cache.ContainsKey(key))
            {
                ISessionManager sessionManager = cache[key];
                return sessionManager;
            }

            ISessionManager newSessionManager = decorated.Build(sessionAlias, type);
            cache[key] = newSessionManager;
            return newSessionManager;
        }
    }
}
