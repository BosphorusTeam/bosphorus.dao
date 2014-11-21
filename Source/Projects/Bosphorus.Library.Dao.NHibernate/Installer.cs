using System.Collections;
using Bosphorus.Container.Castle.Fluent;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.LifeStyle;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Manager;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof (IDao<>))
                    .ImplementedBy(typeof (NHibernateDao<>))
                    .IsFallback()
                    .NamedUnique(),

                allLoadedTypes
                    .BasedOn(typeof (NHibernateDao<>))
                    .WithService
                    .AllInterfaces()
                    .If(type => type != typeof(NHibernateDao<>)),

                Component
                    .For<IDao>()
                    .ImplementedBy<NHibernateDao>()
                    .IsFallback()
                    .NamedUnique(),

                allLoadedTypes
                    .BasedOn(typeof(NHibernateDao))
                    .WithService
                    .AllInterfaces()
                    .If(type => type != typeof(NHibernateDao)),

                Component
                    .For<ISessionManagerFactory>()
                    .Forward<INHibernateSessionManagerFactory>()
                    .ImplementedBy<NHibernateSessionManagerFactory>()
                    .IsFallback()
                    .NamedUnique(),

                Component
                    .For<ISessionManager>()
                    .Forward<INHibernateSessionManager>()
                    .UsingFactoryMethod(BuildSessionManager)
                    .IsFallback(),

                Component
                    .For<ISession>()
                    .Forward<NHibernateSession>()
                    .UsingFactoryMethod(BuildSession)
                    .LifestyleCustom<SessionLifeStyleManager>()
                    .IsFallback()
            );
        }

        private INHibernateSessionManager BuildSessionManager(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            IDictionary creationArguments = creationContext.AdditionalArguments;
            INHibernateSessionManagerFactory sessionManagerFactory = kernel.Resolve<INHibernateSessionManagerFactory>();
            ISessionManager sessionManager = sessionManagerFactory.Build(creationArguments);
            return (INHibernateSessionManager)sessionManager;
        }

        private NHibernateSession BuildSession(IKernel kernel, ComponentModel componentModel, CreationContext creationContext)
        {
            IDictionary creationArguments = creationContext.AdditionalArguments;
            INHibernateSessionManager sessionManager = kernel.Resolve<INHibernateSessionManager>(creationArguments);
            ISession session = sessionManager.OpenSession();
            return (NHibernateSession)session;
        }

    }
}
