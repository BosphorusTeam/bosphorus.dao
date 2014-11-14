using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory.Decoration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ISessionManagerFactory>()
                    .ImplementedBy<NHibernateSessionManagerFactory>(),

                Component
                    .For<ISessionManagerFactory>()
                    .ImplementedBy<CacheDecorator>()
                    .IsDefault()
            );

        }
    }
}
