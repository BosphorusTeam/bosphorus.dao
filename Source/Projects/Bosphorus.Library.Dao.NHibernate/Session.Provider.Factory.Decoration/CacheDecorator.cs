using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory.Decoration
{
    public class CacheDecorator: ISessionManagerFactory
    {
        private readonly ISessionManagerFactory decorated;
        private readonly Dictionary<string, ISessionManager> cache;

        public CacheDecorator(ISessionManagerFactory decorated)
        {
            this.decorated = decorated;
            this.cache = new Dictionary<string, ISessionManager>();
        }

        public ISessionManager Build(string sessionAlias)
        {
            if (cache.ContainsKey(sessionAlias))
            {
                ISessionManager sessionManager = cache[sessionAlias];
                return sessionManager;
            }

            ISessionManager newSessionManager = decorated.Build(sessionAlias);
            cache[sessionAlias] = newSessionManager;
            return newSessionManager;

        }
    }
}
