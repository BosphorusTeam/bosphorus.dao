using System.Collections.Generic;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider
{
    internal class ChainedPersistenceConfigurerProvider : IPersistenceConfigurerProvider
    {
        private readonly IList<IPersistenceConfigurerProvider> chains;

        public ChainedPersistenceConfigurerProvider(IList<IPersistenceConfigurerProvider> chains)
        {
            this.chains = chains;
        }

        public IPersistenceConfigurer GetPersistenceProvider(string sessionAlias)
        {
            foreach (IPersistenceConfigurerProvider chain in chains)
            {
                IPersistenceConfigurer persistenceConfigurer = chain.GetPersistenceProvider(sessionAlias);
                if (persistenceConfigurer == null)
                {
                    continue;
                }

                return persistenceConfigurer;
            }

           throw new PersistenceConfigurerProviderNotFoundException(sessionAlias);
        }
    }
}
