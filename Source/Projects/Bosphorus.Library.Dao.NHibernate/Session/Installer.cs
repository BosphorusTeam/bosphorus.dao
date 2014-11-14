using System.Collections;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao.Decoration;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.LifeStyle;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;
using Castle.Core;
using Castle.Core.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.ModelBuilder;
using Castle.MicroKernel.ModelBuilder.Descriptors;
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
                    .UsingFactoryMethod(BuildSession)
                    .LifestyleCustom<SessionLifeStyleManager>()

            );
        }

        private ISession BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            IDictionary creationArguments = creationContext.AdditionalArguments;
            ISessionManagerFactory sessionManagerFactory = kernel.Resolve<ISessionManagerFactory>();
            ISessionManager sessionManager = sessionManagerFactory.Build(creationArguments);
            ISession session = sessionManager.OpenSession();
            return session;
        }
    }
}
