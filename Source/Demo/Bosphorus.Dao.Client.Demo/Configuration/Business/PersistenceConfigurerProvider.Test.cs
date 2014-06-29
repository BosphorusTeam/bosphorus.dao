using Bosphorus.Dao.NHibernate.Extension.Driver.OracleManaged;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.Client.Demo.Business
{
    public class PersistenceConfigurerProvider : AbstractPersistenceConfigurerProvider
    {
        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            const string dataSource = @"
                  (DESCRIPTION =
                    (ADDRESS = (PROTOCOL = TCP)(HOST = test-esas.araskargo.com.tr)(PORT = 1521))
                    (CONNECT_DATA =
                      (SERVER = DEDICATED)
                      (SERVICE_NAME = esastest)
                    )
                  )
            ";

            string connectionString = string.Format("DATA SOURCE={0};PERSIST SECURITY INFO=True;USER ID={1};Password={2};enlist=dynamic", dataSource, "ESASLIVE", "0racle");

            return
                OracleDataClientConfiguration
                    .Oracle10
                    .Managed()
                    .ConnectionString(connectionString)
                    .ShowSql()
                    .FormatSql();
        }
    }
}