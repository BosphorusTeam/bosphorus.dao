using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using NHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ
{
    public class LinqExtender : AbstractConfigurationProcessor
    {
        protected override void Process(Configuration configuration)
        {
            configuration.LinqToHqlGeneratorsRegistry<LinqToHqlGeneratorsRegistry>();
        }
    }
}
