using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Client.Model;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Client
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .Where(type => typeof(IExecutionItemList).IsAssignableFrom(type) && !type.IsAbstract)
                    .WithService
                    .FirstInterface(),

                Component
                    .For<ClientForm>()
            );
        }
    }
}
