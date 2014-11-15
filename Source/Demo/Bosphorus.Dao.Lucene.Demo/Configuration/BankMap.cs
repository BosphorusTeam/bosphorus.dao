using Bosphorus.Dao.Lucene.Configuration.Map;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Version = Lucene.Net.Util.Version;

namespace Bosphorus.Dao.Lucene.Demo.Configuration
{
    public class BankMap: LuceneMap<Bank>
    {
        public BankMap(Version version) 
            : base(version)
        {
            Key(x => x.No).NotStored();
            Property(x => x.Name).Analyzed();
        }
    }
}
