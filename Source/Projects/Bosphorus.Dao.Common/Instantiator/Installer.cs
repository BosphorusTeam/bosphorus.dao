using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Instantiator
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IInstantiator>()
                    .WithService
                    .AllInterfaces(),

                Component
                    .For<IInstantiator>()
                    .ImplementedBy<DefaultInstantiator>()
                    .IsDefault()
            );

        }
    }
}
