using System;
using System.Collections.Concurrent;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Provider.Factory.Native
{
    internal class CacheDecorator : ILuceneDataProviderFactory
    {
        private readonly ILuceneDataProviderFactory decorated;
        private readonly ConcurrentDictionary<string, LuceneDataProvider> cache;

        public CacheDecorator(ILuceneDataProviderFactory decorated)
        {
            this.decorated = decorated;
            this.cache = new ConcurrentDictionary<string, LuceneDataProvider>();
        }

        public LuceneDataProvider Build(string sessionAlias)
        {
            string key = sessionAlias;
            LuceneDataProvider luceneDataProvider = cache.GetOrAdd(key, newKey => decorated.Build(sessionAlias));
            return luceneDataProvider;
        }

    }
}