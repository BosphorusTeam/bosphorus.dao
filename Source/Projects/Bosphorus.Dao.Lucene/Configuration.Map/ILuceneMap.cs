using Lucene.Net.Linq.Mapping;

namespace Bosphorus.Dao.Lucene.Configuration.Map
{
    public interface ILuceneMap<in TModel>
    {
        IDocumentMapper<TModel> ToDocumentMapper();
    }
}
