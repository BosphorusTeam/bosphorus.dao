using System.Collections;
using System.Collections.Generic;
using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
{
    public class NHibernateSessionManagerFactory : INHibernateSessionManagerFactory
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

        public ISessionManager Build(IDictionary creationArguments)
        {
            string sessionAlias = (string) creationArguments["SessionAlias"];

            ISessionFactory sessionFactory =
                Fluently
                .Configure()
                .Database(() => ConfigurePersister(sessionAlias))
                .Mappings(mappingConfiguration => ConfigureMapping(sessionAlias, mappingConfiguration))
                .ExposeConfiguration(configuration => ProcessConfiguration(sessionAlias, configuration))
                .CurrentSessionContext<NHibernateCurrentSessionContext>()
                .BuildSessionFactory();

            NHibernateSessionManager sessionManager = new NHibernateSessionManager(serviceRegistry, sessionAlias, sessionFactory);
            return sessionManager;
        }

        private IPersistenceConfigurer ConfigurePersister(string sessionAlias)
        {
            IPersistenceConfigurer result = persistenceConfigurerProvider.GetPersistenceProvider(sessionAlias);
            return result;
        }

        private void ProcessConfiguration(string sessionAlias, Configuration configuration)
        {
            configurationProcessor.Process(sessionAlias, configuration);
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