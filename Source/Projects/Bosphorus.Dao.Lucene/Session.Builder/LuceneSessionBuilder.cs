using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.Lucene.Session.Provider.Factory;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Builder
{
    public class LuceneSessionBuilder : ISessionBuilder<LuceneSession> 
    {
        private readonly ILuceneDataProviderFactory luceneDataProviderFactory;

        public LuceneSessionBuilder(ILuceneDataProviderFactory luceneDataProviderFactory)
        {
            this.luceneDataProviderFactory = luceneDataProviderFactory;
        }

        public LuceneSession Construct(string aliasName)
        {
            LuceneDataProvider luceneDataProvider = luceneDataProviderFactory.Build(aliasName);
            LuceneSession session = new LuceneSession(luceneDataProvider);
            return session;
        }

        public void Destruct(LuceneSession session)
        {
            LuceneDataProvider innerSession = session.InnerSession;
            innerSession.IndexWriter.Optimize();
            //TODO: Neden patlıyor acaba burası.
            //innerSession.Dispose();
        }
    }
}
