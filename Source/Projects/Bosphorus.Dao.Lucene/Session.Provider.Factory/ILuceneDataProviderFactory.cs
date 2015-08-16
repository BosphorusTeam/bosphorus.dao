using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Provider.Factory
{
    public interface ILuceneDataProviderFactory
    {
        LuceneDataProvider Build(string aliasName);
    }
}
