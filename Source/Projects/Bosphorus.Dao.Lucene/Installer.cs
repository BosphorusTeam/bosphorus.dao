using System.Collections;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Lucene.Session;
using Bosphorus.Dao.Lucene.Session.Manager.Factory;
using Bosphorus.Dao.Lucene.Session.Manager.Factory.Decoration;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lucene.Net.Util;

namespace Bosphorus.Dao.Lucene
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof(LuceneSession<>))
                    .UsingFactoryMethod(BuildSession),

                Component
                    .For<ILuceneSessionManagerFactory>()
                    .ImplementedBy<DefaultLuceneSessionManagerFactory>(),

                Component
                    .For<ILuceneSessionManagerFactory>()
                    .ImplementedBy<CacheDecorator>()
                    .IsDefault()
            );

        }

        private ISession BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            IDictionary sessionCreationArguments = creationContext.AdditionalArguments;

            ILuceneSessionManagerFactory luceneSessionManagerFactory = kernel.Resolve<ILuceneSessionManagerFactory>();
            ISessionManager luceneSessionManager = luceneSessionManagerFactory.Build(sessionCreationArguments);
            ISession session = luceneSessionManager.OpenSession();
            return session;
        }
    }
}
