using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Provider;
using Castle.Core.Internal;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public class NHibernateSessionProviderFactory : ISessionProviderFactory
    {
        private readonly IPersistenceConfigurerProvider persistenceConfigurerProvider;
        private readonly IAssemblyProvider assemblyProvider;
        private readonly IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders;
        private readonly IList<IConfigurationProcessor> configurationProcessors;

        public NHibernateSessionProviderFactory(IPersistenceConfigurerProvider persistenceConfigurerProvider, IAssemblyProvider assemblyProvider, IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders, IList<IConfigurationProcessor> configurationProcessors)
        {
            this.persistenceConfigurerProvider = persistenceConfigurerProvider;
            this.assemblyProvider = assemblyProvider;
            this.autoPersistenceModelProviders = autoPersistenceModelProviders;
            this.configurationProcessors = configurationProcessors;
        }

        public ISessionProvider Build(string sessionAlias)
        {
            IPersistenceConfigurer persistenceConfigurer = persistenceConfigurerProvider.GetPersistenceProvider(sessionAlias);

            ISessionFactory sessionFactory =
                Fluently
                .Configure()
                .Database(persistenceConfigurer)
                .ExposeConfiguration(
                    cfg => configurationProcessors.ForEach(configurationProcessor => configurationProcessor.Process(cfg))
                )
                .Mappings(
                    m => autoPersistenceModelProviders.ForEach(
                        autoPersistenceModelProvider => m.AutoMappings.Add(autoPersistenceModelProvider.GetAutoPersistenceModel(assemblyProvider))
                    )
                )
                .BuildSessionFactory();

            NHibernateSessionProvider sessionProvider = new NHibernateSessionProvider(sessionFactory);
            return sessionProvider;
        }
    }
}