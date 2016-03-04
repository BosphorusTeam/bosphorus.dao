using Bosphorus.Common.Api.Container;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Common
{
    public class Installer : IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ContainerHolder>()
                    .LifeStyle
                    .Singleton
                    .Start()
            );
        }
    }
}
