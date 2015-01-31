using System.Collections.Generic;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.ConventionApplier;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.HbmMappingProvider;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native
{
    public class DefaultNHibernateSessionFactoryBuilder : INHibernateSessionFactoryBuilder
    {
        private readonly IPersistenceConfigurerProvider persistenceConfigurerProvider;
        private readonly IAssemblyProvider assemblyProvider;
        private readonly IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders;
        private readonly IHbmMappingRegisterer hbmMappingRegisterer;
        private readonly IConventionApplier conventionApplier;
        private readonly IConfigurationProcessor configurationProcessor;

        public DefaultNHibernateSessionFactoryBuilder(IPersistenceConfigurerProvider persistenceConfigurerProvider, IAssemblyProvider assemblyProvider, IList<IAutoPersistenceModelProvider> autoPersistenceModelProviders, IHbmMappingRegisterer hbmMappingRegisterer, IConventionApplier conventionApplier, IConfigurationProcessor configurationProcessor)
        {
            this.persistenceConfigurerProvider = persistenceConfigurerProvider;
            this.assemblyProvider = assemblyProvider;
            this.autoPersistenceModelProviders = autoPersistenceModelProviders;
            this.hbmMappingRegisterer = hbmMappingRegisterer;
            this.conventionApplier = conventionApplier;
            this.configurationProcessor = configurationProcessor;
        }

        public ISessionFactory Build(string sessionAlias)
        {
            return
                Fluently
                .Configure()
                .Database(() => ConfigurePersister(sessionAlias))
                .Mappings(mappingConfiguration => ConfigureMapping(sessionAlias, mappingConfiguration))
                .ExposeConfiguration(configuration => ProcessConfiguration(sessionAlias, configuration))
                .BuildSessionFactory();
        }

        private IPersistenceConfigurer ConfigurePersister(string sessionAlias)
        {
            IPersistenceConfigurer result = persistenceConfigurerProvider.GetPersistenceProvider(sessionAlias);
            return result;
        }

        private void ProcessConfiguration(string sessionAlias, global::NHibernate.Cfg.Configuration configuration)
        {
            configurationProcessor.Process(sessionAlias, configuration);
        }

        private void ConfigureMapping(string sessionAlias, MappingConfiguration mappingConfiguration)
        {
            hbmMappingRegisterer.Apply(sessionAlias, mappingConfiguration.HbmMappings);

            foreach (IAutoPersistenceModelProvider autoPersistenceModelProvider in autoPersistenceModelProviders)
            {
                AutoPersistenceModel autoPersistenceModel = autoPersistenceModelProvider.GetAutoPersistenceModel(assemblyProvider, sessionAlias);
                autoPersistenceModel.Conventions.Setup(conventionFinder => conventionApplier.Apply(sessionAlias, conventionFinder));
                mappingConfiguration.AutoMappings.Add(autoPersistenceModel);
            }
            mappingConfiguration.MergeMappings();
        }

    }
}