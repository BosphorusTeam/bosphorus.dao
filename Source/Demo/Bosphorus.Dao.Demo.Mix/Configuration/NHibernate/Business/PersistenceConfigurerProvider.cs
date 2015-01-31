using Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.Demo.Mix.Configuration.NHibernate.Business
{
    public class PersistenceConfigurerProvider : AbstractPersistenceConfigurerProvider
    {
        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            return
                SQLiteConfiguration
                    .Standard
                    .UsingFile(@".\Demo.db3")
                    .ShowSql()
                    .FormatSql();
        }
    }
}
