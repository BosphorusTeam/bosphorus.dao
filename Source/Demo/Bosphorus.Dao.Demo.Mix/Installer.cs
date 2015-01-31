using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.NHibernate.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.Mix
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IDao<Customer>>()
                    .ImplementedBy<NHibernateStatefulDao<Customer>>(),

                Component
                    .For<IDao<LogModel>>()
                    .ImplementedBy<NHibernateStatelessDao<LogModel>>(),

                Component
                    .For<IDao<Bank>>()
                    .ImplementedBy<LuceneDao<Bank>>()
            );
        }
    }
}
