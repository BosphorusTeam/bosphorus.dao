using System.Collections.Generic;
using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Mapping;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public class NHibernateSessionManagerFactory : ISessionManagerFactory
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly IPersistenceConfigurerProvider persistenceConfigurerProvider;
        private readonly IAssemblyProvider assemblyProvider;
        private readonly IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders;
        private readonly IHbmMappingRegisterer hbmMappingRegisterer;
        private readonly IConventionApplier conventionApplier;
        private readonly IConfigurationProcessor configurationProcessor;

        public NHibernateSessionManagerFactory(IServiceRegistry serviceRegistry, IPersistenceConfigurerProvider persistenceConfigurerProvider, IAssemblyProvider assemblyProvider, IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders, IHbmMappingRegisterer hbmMappingRegisterer, IConventionApplier conventionApplier, IConfigurationProcessor configurationProcessor)
        {
            this.serviceRegistry = serviceRegistry;
            this.persistenceConfigurerProvider = persistenceConfigurerProvider;
            this.assemblyProvider = assemblyProvider;
            this.autoPersistenceModelProviders = autoPersistenceModelProviders;
            this.hbmMappingRegisterer = hbmMappingRegisterer;
            this.conventionApplier = conventionApplier;
            this.configurationProcessor = configurationProcessor;
        }

        public ISessionManager Build(string sessionAlias)
        {
            ISessionFactory sessionFactory =
                Fluently
                .Configure()
                .Database(() => persistenceConfigurerProvider.GetPersistenceProvider(sessionAlias))
                .Mappings(mappingConfiguration => ConfigureMapping(sessionAlias, mappingConfiguration))
                .ExposeConfiguration(configuration => configurationProcessor.Process(sessionAlias, configuration))
                .BuildSessionFactory();

            NHibernateSessionManager sessionManager = new NHibernateSessionManager(serviceRegistry, sessionAlias, sessionFactory);
            return sessionManager;
        }

        private void ConfigureMapping(string sessionAlias, MappingConfiguration mappingConfiguration)
        {
            hbmMappingRegisterer.Apply(sessionAlias, mappingConfiguration.HbmMappings);

            foreach (var autoPersistenceModelProvider in autoPersistenceModelProviders)
            {
                AutoPersistenceModel autoPersistenceModel = autoPersistenceModelProvider.GetAutoPersistenceModel(assemblyProvider, sessionAlias);
                autoPersistenceModel.Conventions.Setup(conventionFinder => conventionApplier.Apply(sessionAlias, conventionFinder));
                mappingConfiguration.AutoMappings.Add(autoPersistenceModel);
            }
            mappingConfiguration.MergeMappings();
        }
    }
}