using Bosphorus.Common.Api.Container;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ISessionRepository>()
                    .ImplementedBy<ConditionalSessionRepository>()
            );
        }
    }
}
