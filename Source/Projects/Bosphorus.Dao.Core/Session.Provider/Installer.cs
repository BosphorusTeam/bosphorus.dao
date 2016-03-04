using Bosphorus.Common.Api.Container;
using Bosphorus.Dao.Core.Session.Provider.Decoration.NullSafe;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ISessionProvider>()
                    .ImplementedBy<TransientSessionProvider>(),

                Component
                    .For<ISessionProvider>()
                    .ImplementedBy<NullSafeDecorator>()
                    .IsDefault(),

                Component
                    .For<ExtensionConfiguration>()
            );
        }
    }
}
