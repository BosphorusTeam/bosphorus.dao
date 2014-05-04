using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Demo.Dal.Configuration
{
    public class LogPersistenceConfigurerProvider : AbstractPersistenceConfigurerProvider
    {
        public LogPersistenceConfigurerProvider()
            : base("LOG")
        {
        }

        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            return
                SQLiteConfiguration
                .Standard
                .ConnectionString(@"data source=.\Demo.db3")
                .ShowSql();
        }
    }
}
