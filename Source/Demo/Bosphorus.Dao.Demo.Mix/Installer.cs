using Bosphorus.Configuration.Core;
using Bosphorus.Configuration.Core.Parameter;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Dao.NHibernate.Stateless.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.Mix
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IParameterProvider>()
                    .ImplementedBy<ParameterProvider>(),

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
