using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao.Decoration;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Decoration;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate.Session
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ISession>()
                    .UsingFactoryMethod(BuildSession, true)
                    .LifeStyle.Singleton
            );

            container.Kernel.GetHandler(typeof(ISession)).ComponentModel.LifestyleType = LifestyleType.Thread;

        }

        private ISession BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            ISessionManagerFactory sessionManagerFactory = kernel.Resolve<ISessionManagerFactory>();
            ISessionManager sessionManager = sessionManagerFactory.Build("Default");
            ISession session = sessionManager.OpenSession();
            return session;
        }
    }
}
