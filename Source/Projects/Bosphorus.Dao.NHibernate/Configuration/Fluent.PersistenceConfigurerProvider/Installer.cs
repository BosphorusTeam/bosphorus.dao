using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IPersistenceConfigurerProvider>()
                    .WithService
                    .FromInterface(),

                Component
                    .For<IPersistenceConfigurerProvider>()
                    .ImplementedBy<ChainedPersistenceConfigurerProvider>().IsDefault()
            );

        }
    }
}
