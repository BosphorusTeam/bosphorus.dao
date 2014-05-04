using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.NHibernate.Demo.Dal.Configuration
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
