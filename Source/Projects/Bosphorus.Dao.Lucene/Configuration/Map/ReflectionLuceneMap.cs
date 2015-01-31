using Lucene.Net.Linq.Mapping;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Configuration.Map
{
    public class ReflectionLuceneMap<TModel> : ILuceneMap<TModel>
    {
        public IDocumentMapper<TModel> ToDocumentMapper(Version version)
        {
            ReflectionDocumentMapper<TModel> reflectionDocumentMapper = new ReflectionDocumentMapper<TModel>(version);
            return reflectionDocumentMapper;
        }
    }
}
