using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<IHbmMappingRegisterer>()
                    .WithService
                    .FromInterface(),

                Component
                    .For<IHbmMappingRegisterer>()
                    .ImplementedBy<CompositeHbmMappingRegisterer>().IsDefault()
            );

        }
    }
}
