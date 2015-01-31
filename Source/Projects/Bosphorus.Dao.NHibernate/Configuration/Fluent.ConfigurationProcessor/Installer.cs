using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IConfigurationProcessor>()
                    .WithService
                    .FromInterface(),

                Component
                    .For<IConfigurationProcessor>()
                    .ImplementedBy<CompositeConfigurationProcessor>().IsDefault()
            );

        }
    }
}
