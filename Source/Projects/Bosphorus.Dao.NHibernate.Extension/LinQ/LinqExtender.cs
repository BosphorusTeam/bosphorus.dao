using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor;
using NHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Extension.LinQ
{
    public class LinqExtender : AbstractConfigurationProcessor
    {
        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            configuration.LinqToHqlGeneratorsRegistry<LinqToHqlGeneratorsRegistry>();
        }
    }
}
