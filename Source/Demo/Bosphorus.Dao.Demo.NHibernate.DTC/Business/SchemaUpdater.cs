using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Demo.NHibernate.DTC.Business
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        protected override void Process(Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);
        }
    }
}
