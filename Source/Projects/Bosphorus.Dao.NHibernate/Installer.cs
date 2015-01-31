using Bosphorus.Container.Castle.Fluent.Decoration;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native;
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
                    .For(typeof(INHibernateStatefulDao<>))
                    .ImplementedBy(typeof(NHibernateStatefulDao<>))
                    .NamedAutomatically("NHibernateStatefulDao"),

                Component
                    .For<ISessionProviderFactory<NHibernateStatefulSession>>()
                    .ImplementedBy<NHibernateStatefulSessionProviderFactory>()
                    .NamedAutomatically("NHibernateStatefulSessionProviderFactory"),

                Decorator
                    .Of<ISessionProviderFactory<NHibernateStatefulSession>>()
                    .Is<Core.Session.Provider.Factory.Decoration.CacheDecorator<NHibernateStatefulSession>>(),

                Component
                    .For(typeof(INHibernateStatelessDao<>))
                    .ImplementedBy(typeof(NHibernateStatelessDao<>))
                    .NamedAutomatically("INHibernateStatelessDao"),

                Component
                    .For<ISessionProviderFactory<NHibernateStatelessSession>>()
                    .ImplementedBy<NHibernateStatelessSessionProviderFactory>()
                    .NamedAutomatically("NHibernateStatelessSessionProviderFactory"),

                Decorator
                    .Of<ISessionProviderFactory<NHibernateStatelessSession>>()
                    .Is<Core.Session.Provider.Factory.Decoration.CacheDecorator<NHibernateStatelessSession>>(),

                Component
                    .For<INHibernateSessionFactoryBuilder>()
                    .ImplementedBy<DefaultNHibernateSessionFactoryBuilder>(),

                Decorator
                    .Of<INHibernateSessionFactoryBuilder>()
                    .Is<CacheDecorator>()
            );
        }

    }
}
