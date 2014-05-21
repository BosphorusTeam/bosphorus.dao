using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.NHibernate.Demo.Client.Business
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);
        }
    }
}
