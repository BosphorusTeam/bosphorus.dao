using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.Lucene.Session.Provider.Factory;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Builder
{
    public class LuceneSessionBuilder : AbstractSessionBuilder<LuceneSession> 
    {
        private readonly ILuceneDataProviderFactory luceneDataProviderFactory;

        public LuceneSessionBuilder(ILuceneDataProviderFactory luceneDataProviderFactory)
        {
            this.luceneDataProviderFactory = luceneDataProviderFactory;
        }

        protected override LuceneSession ConstructInternal(string aliasName)
        {
            LuceneDataProvider luceneDataProvider = luceneDataProviderFactory.Build(aliasName);
            LuceneSession session = new LuceneSession(luceneDataProvider);
            return session;
        }

        protected override void DestructInternal(LuceneSession typedSession)
        {
            var adapted = typedSession.GetNativeSession<LuceneDataProvider>();
            adapted.IndexWriter.Optimize();
            adapted.IndexWriter.Commit();
            adapted.IndexWriter.Dispose();
            adapted.Dispose();
        }
    }
}
