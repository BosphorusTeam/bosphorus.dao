using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.Demo.NHibernate.DTC.Log
{
    public class SchemaUpdater: AbstractConfigurationProcessor
    {
        public SchemaUpdater()
            : base("LOG")
        {
        }

        protected override void Process(global::NHibernate.Cfg.Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);
        }
    }
}
