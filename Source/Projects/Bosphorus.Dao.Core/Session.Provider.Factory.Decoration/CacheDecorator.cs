using System.Collections.Concurrent;

namespace Bosphorus.Dao.Core.Session.Provider.Factory.Decoration
{
    public class CacheDecorator<TSession> : ISessionProviderFactory<TSession> 
        where TSession : ISession
    {
        private readonly ISessionProviderFactory<TSession> decorated;
        private readonly ConcurrentDictionary<string, ISessionProvider<TSession>> cache;

        public CacheDecorator(ISessionProviderFactory<TSession> decorated)
        {
            this.decorated = decorated;
            this.cache = new ConcurrentDictionary<string, ISessionProvider<TSession>>();
        }

        public ISessionProvider<TSession> Build(string sessionAlias)
        {
            ISessionProvider<TSession> result = cache.GetOrAdd(sessionAlias, BuildSessionProvider);
            return result;
        }

        private ISessionProvider<TSession> BuildSessionProvider(string sessionAlias)
        {
            ISessionProvider<TSession> sessionProvider = decorated.Build(sessionAlias);
            return sessionProvider;
        }
    }
}