using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Common.Metadata.Class;
using Bosphorus.Dao.Common.Metadata.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common.Metadata
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IMetadataRegisterer<>))
                    .WithService
                    .FromInterface(),

                allLoadedTypes
                    .BasedOn(typeof(IMetadataBuilder<>))
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof(IMetadataProvider<>))
                    .ImplementedBy(typeof(DefaultMetadataProvider<>)),

                Component
                    .For(typeof(ClassMetadataProvider<>)),

                Component
                    .For<GenericClassMetadataProvider>()
            );
        }
    }
}
