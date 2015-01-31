using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Bosphorus.Dao.Lucene.Session.Provider.Factory.Native;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Provider.Factory
{
    public class LuceneSessionProviderFactory<TModel> : ISessionProviderFactory<LuceneSession<TModel>> 
        where TModel : new()
    {
        private readonly ILuceneDataProviderFactory luceneDataProviderFactory;
        private readonly ILuceneMap<TModel> luceneMap;

        public LuceneSessionProviderFactory(ILuceneDataProviderFactory luceneDataProviderFactory, ILuceneMap<TModel> luceneMap)
        {
            this.luceneDataProviderFactory = luceneDataProviderFactory;
            this.luceneMap = luceneMap;
        }

        public ISessionProvider<LuceneSession<TModel>> Build(string sessionAlias)
        {
            LuceneDataProvider luceneDataProvider = luceneDataProviderFactory.Build(sessionAlias, typeof(TModel));
            LuceneSessionProvider<TModel> sessionProvider = new LuceneSessionProvider<TModel>(sessionAlias, luceneDataProvider, luceneMap);
            return sessionProvider;
        }
    }
}
