using System;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Session.Provider.Factory.Native
{
    public interface ILuceneDataProviderFactory
    {
        LuceneDataProvider Build(string sessionAlias, Type modelType);
    }
}
