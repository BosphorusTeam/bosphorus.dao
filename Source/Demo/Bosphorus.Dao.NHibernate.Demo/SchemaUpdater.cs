using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.NHibernate.Demo
{
    public class SchemaUpdater: IConfigurationProcessor
    {
        public void Process(Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);
        }
    }
}
