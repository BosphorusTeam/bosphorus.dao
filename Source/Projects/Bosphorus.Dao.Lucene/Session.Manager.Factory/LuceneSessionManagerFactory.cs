using System;
using System.Collections;
using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.Lucene.Configuration;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Linq;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory
{
    public class LuceneSessionManagerFactory : ILuceneSessionManagerFactory
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly ILuceneDataProviderBuilder luceneDataProviderBuilder;

        public LuceneSessionManagerFactory(IServiceRegistry serviceRegistry, ILuceneDataProviderBuilder luceneDataProviderBuilder)
        {
            this.serviceRegistry = serviceRegistry;
            this.luceneDataProviderBuilder = luceneDataProviderBuilder;
        }

        public ISessionManager Build(IDictionary creationArguments)
        {
            Type type = (Type)creationArguments["Type"];
            Type genericType = typeof(LuceneSessionManager<>).MakeGenericType(type);
            LuceneDataProvider luceneDataProvider = luceneDataProviderBuilder.Build(type);

            object instance = Activator.CreateInstance(genericType, serviceRegistry, luceneDataProvider);
            ISessionManager sessionManager = (ISessionManager)instance;
            return sessionManager;
        }
    }
}