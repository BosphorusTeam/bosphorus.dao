using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Fluent.Composition;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Common.Instantiator;
using Bosphorus.Dao.Common.Mapper.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Common
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Compositor
                    .Of<IInstantiator>()
                    .In(allLoadedTypes)
                    .ImplementedBy<CompositeInstantiator>(),

                Compositor
                    .Of<IMapper>()
                    .In(allLoadedTypes)
                    .ImplementedBy<CompositeMapper>()
            );

        }
    }
}
