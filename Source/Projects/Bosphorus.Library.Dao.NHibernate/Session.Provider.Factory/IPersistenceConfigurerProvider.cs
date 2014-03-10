using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public interface IPersistenceConfigurerProvider
    {
        IPersistenceConfigurer GetPersistenceProvider(string sessionAlias);
    }
}
