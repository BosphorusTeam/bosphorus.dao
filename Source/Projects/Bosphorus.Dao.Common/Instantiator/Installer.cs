using Bosphorus.Container.Castle.Registration.Handler.Generic;
using Bosphorus.Container.Castle.Registration.Handler.Generic.Implementation;
using Bosphorus.Container.Castle.Registration.Handler.Generic.Selector;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Common.Common;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Instantiator
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register (
                allLoadedTypes
                    .BasedOn(typeof(IInstantiator<>))
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof(IInstantiator<>))
                    .ImplementedBy(typeof(ListInstantiator<>), GenericImplementationArgs.Transformed.ListTrimmed, GenericService.AllArgs.IsList),

                Component
                    .For(typeof(IInstantiator<>))
                    .ImplementedBy(typeof(NewConstaintInstantiator<>), GenericService.AllArgs.HasDefaultConstructor)
            );
        }
    }
}
