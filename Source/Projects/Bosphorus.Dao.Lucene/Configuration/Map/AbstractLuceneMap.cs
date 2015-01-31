using Lucene.Net.Linq.Fluent;
using Lucene.Net.Linq.Mapping;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Configuration.Map
{
    public abstract class AbstractLuceneMap<TModel>: ILuceneMap<TModel>
    {
        protected abstract void Map(ClassMap<TModel> mapping);

        public IDocumentMapper<TModel> ToDocumentMapper(Version version)
        {
            ClassMap<TModel> classMap = new ClassMap<TModel>(version);
            this.Map(classMap);
            IDocumentMapper<TModel> documentMapper = classMap.ToDocumentMapper();
            return documentMapper;
        }
        
    }
}
