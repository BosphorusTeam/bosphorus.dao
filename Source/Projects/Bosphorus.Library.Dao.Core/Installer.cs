using Bosphorus.Container.Castle.Fluent;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session.LifeStyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ISessionLifeStyleProvider>()
                    .ImplementedBy<SessionLifeStyleProvider>()
                    .IsFallback()
                    .NamedUnique()
            );
        }
    }
}
