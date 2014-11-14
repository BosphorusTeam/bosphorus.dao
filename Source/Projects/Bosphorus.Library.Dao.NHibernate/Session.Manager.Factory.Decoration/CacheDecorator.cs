using System.Collections;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory.Decoration
{
    public class CacheDecorator: ISessionManagerFactory
    {
        private readonly ISessionManagerFactory decorated;
        private readonly Dictionary<IDictionary, ISessionManager> cache;
        private static readonly IEqualityComparer<IDictionary> equalityComparer;

        static CacheDecorator()
        {
            equalityComparer = new DictionaryElementsEqualityComparer();
        }

        public CacheDecorator(ISessionManagerFactory decorated)
        {
            this.decorated = decorated;
            this.cache = new Dictionary<IDictionary, ISessionManager>(equalityComparer);
        }

        public ISessionManager Build(IDictionary creationArguments)
        {
            if (cache.ContainsKey(creationArguments))
            {
                ISessionManager sessionManager = cache[creationArguments];
                return sessionManager;
            }

            ISessionManager newSessionManager = decorated.Build(creationArguments);
            cache[creationArguments] = newSessionManager;
            return newSessionManager;

        }
    }
}
