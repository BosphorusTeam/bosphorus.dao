using Bosphorus.Common.Api.Container;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
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
