using Bosphorus.Dao.NHibernate.Common;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public abstract class AbstractPersistenceConfigurerProvider : IPersistenceConfigurerProvider
    {
        private readonly string sessionAlias;

        protected AbstractPersistenceConfigurerProvider()
            : this(SessionAlias.Default)
        {
        }

        protected AbstractPersistenceConfigurerProvider(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
        }

        public IPersistenceConfigurer GetPersistenceProvider(string sessionAlias)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return null;
            }

            IPersistenceConfigurer persistenceConfigurer = GetPersistenceProvider();
            return persistenceConfigurer;
        }

        protected abstract IPersistenceConfigurer GetPersistenceProvider();
    }
}