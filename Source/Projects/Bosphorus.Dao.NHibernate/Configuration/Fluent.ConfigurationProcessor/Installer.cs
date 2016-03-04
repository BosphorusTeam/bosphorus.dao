using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor
{
    public class Installer : IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn<IConfigurationProcessor>()
                    .WithService
                    .FromInterface()
                    .ConfigureFor<CompositeConfigurationProcessor>(registration => registration.IsDefault())
            );
        }
    }
}
