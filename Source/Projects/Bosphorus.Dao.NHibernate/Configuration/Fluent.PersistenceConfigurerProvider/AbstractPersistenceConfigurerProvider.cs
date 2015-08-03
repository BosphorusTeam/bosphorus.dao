using Bosphorus.Dao.Core.Common;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider
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