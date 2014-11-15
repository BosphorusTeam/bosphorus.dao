using System.Collections;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.LifeStyle;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Lucene.Configuration;
using Bosphorus.Dao.Lucene.Session;
using Bosphorus.Dao.Lucene.Session.Manager;
using Bosphorus.Dao.Lucene.Session.Manager.Factory;
using Bosphorus.Dao.Lucene.Session.Manager.Factory.Decoration;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Lucene
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                allLoadedTypes
                    .BasedOn<ILuceneDataProviderBuilder>()
                    .WithService
                    .FromInterface(),

                Component
                    .For(typeof(LuceneSession<>))
                    .UsingFactoryMethod(BuildSession)
                    .LifestyleCustom<SessionLifeStyleManager>(),

                Component
                    .For<ILuceneSessionManager>()
                    .UsingFactoryMethod(BuildSessionManager),

                Component
                    .For<ILuceneSessionManagerFactory>()
                    .ImplementedBy<LuceneSessionManagerFactory>(),

                Component
                    .For<ILuceneSessionManagerFactory>()
                    .ImplementedBy<CacheDecorator>()
                    .IsDefault()
            );

        }

        private ISession BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            IDictionary creationArguments = creationContext.AdditionalArguments;
            ILuceneSessionManager sessionManager = kernel.Resolve<ILuceneSessionManager>(creationArguments);
            ISession session = sessionManager.OpenSession();
            return session;
        }

        private ILuceneSessionManager BuildSessionManager(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            IDictionary creationArguments = creationContext.AdditionalArguments;
            ILuceneSessionManagerFactory sessionManagerFactory = kernel.Resolve<ILuceneSessionManagerFactory>();
            ISessionManager sessionManager = sessionManagerFactory.Build(creationArguments);
            return (ILuceneSessionManager) sessionManager;
        }
    }
}
