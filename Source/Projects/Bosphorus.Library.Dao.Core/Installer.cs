using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao;
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
                allLoadedTypes
                    .BasedOn(typeof(IDao<>))
                    .WithService
                    .AllInterfaces(),

                allLoadedTypes    
                    .BasedOn(typeof(IDao))
                    .WithService
                    .FromInterface()
            );
        }
    }
}
