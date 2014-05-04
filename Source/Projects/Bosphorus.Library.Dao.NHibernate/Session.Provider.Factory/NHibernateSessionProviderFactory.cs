using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using Castle.Core.Internal;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public class NHibernateSessionProviderFactory : ISessionProviderFactory
    {
        private readonly IPersistenceConfigurerProvider persistenceConfigurerProvider;
        private readonly IAssemblyProvider assemblyProvider;
        private readonly IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders;
        private readonly IConfigurationProcessor configurationProcessor;

        public NHibernateSessionProviderFactory(IPersistenceConfigurerProvider persistenceConfigurerProvider, IAssemblyProvider assemblyProvider, IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders, IConfigurationProcessor configurationProcessor)
        {
            this.persistenceConfigurerProvider = persistenceConfigurerProvider;
            this.assemblyProvider = assemblyProvider;
            this.autoPersistenceModelProviders = autoPersistenceModelProviders;
            this.configurationProcessor = configurationProcessor;
        }

        public ISessionProvider Build(string sessionAlias)
        {
            IPersistenceConfigurer persistenceConfigurer = persistenceConfigurerProvider.GetPersistenceProvider(sessionAlias);

            ISessionFactory sessionFactory =
                Fluently
                .Configure()
                .Database(persistenceConfigurer)
                .ExposeConfiguration(configuration => configurationProcessor.Process(sessionAlias, configuration))
                .Mappings(
                    m => autoPersistenceModelProviders.ForEach(
                        autoPersistenceModelProvider => m.AutoMappings.Add(autoPersistenceModelProvider.GetAutoPersistenceModel(assemblyProvider, sessionAlias))
                    )
                )
                .BuildSessionFactory();

            NHibernateSessionProvider sessionProvider = new NHibernateSessionProvider(sessionAlias, sessionFactory);
            return sessionProvider;
        }
    }
}