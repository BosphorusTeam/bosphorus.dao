using System;
using System.Collections;
using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Linq;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Session.Manager.Factory
{
    public class DefaultLuceneSessionManagerFactory : ISessionManagerFactory
    {
        private readonly IServiceRegistry serviceRegistry;

        public DefaultLuceneSessionManagerFactory(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public ISessionManager Build(IDictionary creationArguments)
        {
            Type type = (Type)creationArguments["Type"];
            Type genericType = typeof(LuceneSessionManager<>).MakeGenericType(type);

            StandardAnalyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);
            Directory directory = FSDirectory.Open(@"c:\temp\"+type.FullName);
            //directory = new RAMDirectory(directory);
            IndexWriter.MaxFieldLength maxFieldLength = new IndexWriter.MaxFieldLength(25000);
            IndexWriter writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

            LuceneDataProvider provider = new LuceneDataProvider(directory, analyzer, Version.LUCENE_30, writer);
            provider.Settings.EnableMultipleEntities = false;

            object instance = Activator.CreateInstance(genericType, serviceRegistry, provider);

            ISessionManager sessionManager = (ISessionManager)instance;
            return sessionManager;
        }
    }
}