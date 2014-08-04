using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao.Decoration;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;
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
                allLoadedTypes
                    .BasedOn<ISessionLifeStyleProvider>()
                    .WithService
                    .AllInterfaces(),

                Component
                    .For<ISession>()
                    .UsingFactoryMethod(BuildSession, true)
                    .LifeStyle.Singleton

            );

            ISessionLifeStyleProvider sessionLifeStyleProvider = container.Resolve<ISessionLifeStyleProvider>();
            LifestyleType lifestyleType = sessionLifeStyleProvider.GetLifestyle();
            container.Kernel.GetHandler(typeof(ISession)).ComponentModel.LifestyleType = lifestyleType;
        }

        private ISession BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            string sessionAlias = (string) creationContext.AdditionalArguments["SessionAlias"];
            ISessionManagerFactory sessionManagerFactory = kernel.Resolve<ISessionManagerFactory>();
            ISessionManager sessionManager = sessionManagerFactory.Build(sessionAlias);
            ISession session = sessionManager.OpenSession();
            return session;
        }
    }
}
