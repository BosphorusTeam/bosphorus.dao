using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider
{
    public interface IPersistenceConfigurerProvider
    {
        IPersistenceConfigurer GetPersistenceProvider(string sessionAlias);
    }
}
