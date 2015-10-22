using Bosphorus.Container.Castle.Registration.Handler.Generic.Implementation;
using Bosphorus.Container.Castle.Registration.Handler.Generic.Selector;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Unflattener
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IUnflattener<,>))
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof(IUnflattener<,>))
                    .ImplementedBy(typeof(ListUnflattener<,>), GenericImplementationArgs.Transformed.ListTrimmed, GenericService.AllArgs.IsList),

                Component
                    .For(typeof(IUnflattener<,>))
                    .ImplementedBy(typeof(EchoUnflattener<>), GenericImplementationArgs.Distinct, GenericService.AllArgs.IsPrimitive),

                Component
                    .For(typeof(IUnflattener<,>))
                    .ImplementedBy(typeof(ValueInjectorUnflatener<,>)),

                Component
                    .For<GenericUnflattener>()
            );
        }
    }

}
