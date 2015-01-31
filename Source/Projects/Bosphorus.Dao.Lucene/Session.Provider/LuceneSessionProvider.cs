using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Lucene.Net.Linq;
using Lucene.Net.Linq.Mapping;

namespace Bosphorus.Dao.Lucene.Session.Provider
{
    public class LuceneSessionProvider<TModel> : AbstractSessionProvider<LuceneSession<TModel>>
        where TModel : new()
    {
        private readonly LuceneDataProvider luceneDataProvider;
        private readonly IDocumentMapper<TModel> documentMapper;

        public LuceneSessionProvider(string sessionAlias, LuceneDataProvider luceneDataProvider, ILuceneMap<TModel> luceneMap)
            : base(sessionAlias)
        {
            this.luceneDataProvider = luceneDataProvider;
            this.documentMapper = luceneMap.ToDocumentMapper(luceneDataProvider.LuceneVersion);
        }

        public override LuceneSession<TModel> OpenSession()
        {
            ISession<TModel> nativeSession = luceneDataProvider.OpenSession(documentMapper);
            LuceneSession<TModel> session = new LuceneSession<TModel>(nativeSession);
            return session;
        }

        public override void CloseSession(LuceneSession<TModel> session)
        {
            session.Dispose();
        }
    }
}
