using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.Demo.Configuration.NHibernatee.Mapping;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using Bosphorus.Dao.NHibernate.Extension.LinQ;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;

namespace Bosphorus.Dao.Demo.Configuration.NHibernatee
{
    public class NHibernateSessionFactoryFactory: INHibernateSessionFactoryFactory
    {
        public ISessionFactory Build(string sessionAlias)
        {
            return Fluently
                .Configure()
                .Database(Database)
                .Mappings(mappingConfiguration => Mappings(sessionAlias, mappingConfiguration))
                .ExposeConfiguration(configuration => ExposeConfiguration(sessionAlias, configuration))
                .BuildSessionFactory();
        }

        private IPersistenceConfigurer Database()
        {
            return SQLiteConfiguration
                .Standard
                .ConnectionString(@"data source=.\Demo.db3")
                .ShowSql()
                .FormatSql();
        }

        private void Mappings(string sessionAlias, MappingConfiguration mappingConfiguration)
        {
            if (sessionAlias == SessionAlias.Default)
            {
                mappingConfiguration.AutoMappings.Add(
                    AutoMap
                    .AssemblyOf<Customer>()
                    .Where(type => type.Namespace == typeof(Customer).Namespace)
                    .UseOverridesFromAssemblyOf<AccountOverride>()
                    .Conventions.Add<Dao.NHibernate.Extension.Convention.UpperCaseTableName.Convention>()
                    .Conventions.Add<Dao.NHibernate.Extension.Convention.UpperCaseColumnName.Convention>()
                    .Conventions.Add<Dao.NHibernate.Extension.Convention.UpperCaseString.Convention>()
                    .Conventions.Add(new Dao.NHibernate.Extension.Convention.TablePrefix.Convention("X"))
                    .Conventions.Add(new Dao.NHibernate.Extension.Convention.Eumeration.Convention())
                    .Conventions.Add(DynamicUpdate.AlwaysTrue())
                );
                mappingConfiguration.HbmMappings.AddClasses(typeof(AccountOverride));
            }

            if (sessionAlias == "LOG")
            {
                mappingConfiguration.AutoMappings.Add(
                    AutoMap
                        .AssemblyOf<LogModel>()
                        .Where(type => type.Namespace == typeof(LogModel).Namespace)
                );
            }
        }

        private void ExposeConfiguration(string sessionAlias, global::NHibernate.Cfg.Configuration configuration)
        {
            configuration.LinqToHqlGeneratorsRegistry<LinqToHqlGeneratorsRegistry>();
            if (sessionAlias == SessionAlias.Default)
            {
                BusinessSchemaUpdater.Process(configuration);
            }
            if (sessionAlias == "LOG")
            {
                LogSchemaUpdater.Process(configuration);
            }
        }

    }
}
