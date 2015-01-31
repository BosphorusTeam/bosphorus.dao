using Lucene.Net.Linq.Mapping;
using Lucene.Net.Util;

namespace Bosphorus.Dao.Lucene.Configuration.Map
{
    public interface ILuceneMap<in TModel>
    {
        IDocumentMapper<TModel> ToDocumentMapper(Version version);
    }
}
