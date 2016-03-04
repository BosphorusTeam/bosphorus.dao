using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Dao.NHibernate.Stateless.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    public class Installer: IDemoInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(IDao<>))
                    .ImplementedBy(typeof(NHibernateStatefulDao<>)),

                Component
                    .For<IDao<LogModel>>()
                    .ImplementedBy<NHibernateStatelessDao<LogModel>>()
            );
        }
    }
}
