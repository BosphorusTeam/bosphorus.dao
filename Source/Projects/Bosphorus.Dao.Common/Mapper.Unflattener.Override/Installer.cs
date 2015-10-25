using Bosphorus.Container.Castle.Registration.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Unflattener.Override
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof(IUnflattenerOverride<,>))
                    .ImplementedBy(typeof(NullUnflattenerOverride<,>)),

                allLoadedTypes
                    .BasedOn(typeof(IUnflattenerOverride<,>))
                    .WithService
                    .FromInterface()
            );
        }
    }

}
