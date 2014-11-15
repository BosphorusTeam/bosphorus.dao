using System;
using Lucene.Net.Linq;

namespace Bosphorus.Dao.Lucene.Configuration
{
    public interface ILuceneDataProviderBuilder
    {
        LuceneDataProvider Build(Type modelType);
    }
}
