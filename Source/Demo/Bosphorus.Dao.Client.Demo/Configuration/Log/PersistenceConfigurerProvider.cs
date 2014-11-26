using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.Client.Demo.Configuration.Log
{
    public class PersistenceConfigurerProvider : AbstractPersistenceConfigurerProvider
    {
        public PersistenceConfigurerProvider()
            : base("LOG")
        {
        }

        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            return
                SQLiteConfiguration
                    .Standard
                    .ConnectionString(@"data source=.\Demo.db3")
                    .ShowSql()
                    .FormatSql();
        }
    }
}
