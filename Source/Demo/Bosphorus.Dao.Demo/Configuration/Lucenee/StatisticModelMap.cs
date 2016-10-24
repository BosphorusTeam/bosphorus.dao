using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Lucene.Net.Linq.Fluent;

namespace Bosphorus.Dao.Demo.Configuration.Lucenee
{
    public class StatisticModelMap: AbstractLuceneMap<StatisticModel>
    {
        protected override void Map(ClassMap<StatisticModel> mapping)
        {
            mapping.Key(x => x.Id).NotStored();
            mapping.Property(x => x.Elapsed).Analyzed();
        }
    }
}
