using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Dao
{
    public class Installer: IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<SessionDaoRegistry>(),

                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn<ISessionDaoRegisterer>()
                    .WithService
                    .AllInterfaces()
            );
        }
    }
}
