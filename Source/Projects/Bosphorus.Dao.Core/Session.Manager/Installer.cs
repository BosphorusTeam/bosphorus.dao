using Bosphorus.Container.Castle.Registration.Installer;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ApplicationSessionManager>()
                    .LifeStyle
                    .Singleton
                    .Start(),

                Component
                    .For<CallSessionManager>()
                    .LifeStyle
                    .Singleton
                    .Start()
            );
        }
    }
}
