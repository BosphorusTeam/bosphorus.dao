using Bosphorus.Common.Api.Container;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Dao.NHibernate.Stateless.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.NHibernate
{
    public class Installer: IBosphorusInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof (INHibernateStatefulDao<>))
                    .ImplementedBy(typeof (NHibernateStatefulDao<>))
                    .NamedFull(),

                Component
                    .For(typeof (INHibernateStatelessDao<>))
                    .ImplementedBy(typeof (NHibernateStatelessDao<>))
                    .NamedFull()

                //Component
                //    .For<INHibernateSessionFactoryFactory>()
                //    .ImplementedBy<DefaultNHibernateSessionFactoryFactory>(),

                //Component
                //    .For<INHibernateSessionFactoryFactory>()
                //    .ImplementedBy<CacheDecorator>()
                //    .IsDefault()
            );
        }
    }
}
