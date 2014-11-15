using Lucene.Net.Linq.Fluent;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Configuration.Map
{
    public class LuceneMap<TModel>: ClassMap<TModel>, ILuceneMap<TModel>
    {
        public LuceneMap(Version version) 
            : base(version)
        {
        }
    }
}
