using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Lucene.Configuration.Map;
using Lucene.Net.Linq.Fluent;

namespace Bosphorus.Dao.Lucene.Demo.Configuration
{
    public class BankMap: AbstractLuceneMap<Bank>
    {
        protected override void Map(ClassMap<Bank> mapping)
        {
            mapping.Key(x => x.No).NotStored();
            mapping.Property(x => x.Name).Analyzed();
        }
    }
}
