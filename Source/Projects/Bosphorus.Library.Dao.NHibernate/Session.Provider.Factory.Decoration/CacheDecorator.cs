using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory.Decoration
{
    public class CacheDecorator: ISessionProviderFactory
    {
        private readonly ISessionProviderFactory decorated;
        private readonly Dictionary<string, ISessionProvider> cache;

        public CacheDecorator(ISessionProviderFactory decorated)
        {
            this.decorated = decorated;
            this.cache = new Dictionary<string, ISessionProvider>();
        }

        public ISessionProvider Build(string sessionAlias)
        {
            if (cache.ContainsKey(sessionAlias))
            {
                ISessionProvider sessionProvider = cache[sessionAlias];
                return sessionProvider;
            }

            ISessionProvider newSessionProvider = decorated.Build(sessionAlias);
            cache[sessionAlias] = newSessionProvider;
            return newSessionProvider;

        }
    }
}
