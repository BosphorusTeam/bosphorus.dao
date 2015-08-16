using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Fluent;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Dao.NHibernate.Stateless.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof(INHibernateStatefulDao<>))
                    .ImplementedBy(typeof(NHibernateStatefulDao<>))
                    .NamedUnique(),

                Component
                    .For(typeof(INHibernateStatelessDao<>))
                    .ImplementedBy(typeof(NHibernateStatelessDao<>))
                    .NamedUnique(),

                Component
                    .For<INHibernateSessionFactoryBuilder>()
                    .ImplementedBy<DefaultNHibernateSessionFactoryBuilder>()
                /*
                Decorator
                    .Of<INHibernateSessionFactoryBuilder>()
                    .Is<CacheDecorator>()
                */
            );
        }

    }
}
