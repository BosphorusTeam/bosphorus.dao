using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider
{
    public interface IPersistenceConfigurerProvider
    {
        IPersistenceConfigurer GetPersistenceProvider(string sessionAlias);
    }
}
