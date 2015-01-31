using Bosphorus.Container.Castle.Registration;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
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
