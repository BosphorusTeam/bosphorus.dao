using Bosphorus.Container.Castle.Registration.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Mapper.Flattener.Override
{
    public class Installer : AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
               Component
                    .For(typeof (IFlattenerOverride<,>))
                    .ImplementedBy(typeof (NullFlattenerOverride<,>)),

                allLoadedTypes
                    .BasedOn(typeof (IFlattenerOverride<,>))
                    .WithService
                    .FromInterface()
                );
        }
    }
}