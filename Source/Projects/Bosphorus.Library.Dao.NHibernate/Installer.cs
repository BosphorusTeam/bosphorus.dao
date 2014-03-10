using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Decoration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ISessionProviderFactory>()
                    .ImplementedBy<NHibernateSessionProviderFactory>(),

                Component
                    .For<ISessionProviderFactory>()
                    .ImplementedBy<CacheDecorator>().IsDefault(),

                allLoadedTypes
                    .BasedOn<IAutoPersistenceModelProvider>()
                    .WithService
                    .FromInterface(),

                allLoadedTypes
                    .BasedOn<IPersistenceConfigurerProvider>()
                    .WithService
                    .FromInterface(),

                allLoadedTypes
                    .BasedOn<IConfigurationProcessor>()
                    .WithService
                    .FromInterface()
            );

        }
    }
}
