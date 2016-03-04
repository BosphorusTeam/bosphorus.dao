using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.DTC
{
    public class Installer: IDemoInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IDao<Customer>>()
                    .ImplementedBy<NHibernateStatefulDao<Customer>>(),

                Component
                    .For<IDao<LogModel>>()
                    .ImplementedBy<NHibernateStatefulDao<LogModel>>()

            );
        }
    }
}
