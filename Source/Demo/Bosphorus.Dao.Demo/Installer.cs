using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.Demo.Configuration.Lucenee;
using Bosphorus.Dao.Demo.Configuration.NHibernatee;
using Bosphorus.Dao.Lucene.Dao;
using Bosphorus.Dao.Lucene.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Dao.NHibernate.Stateless.Dao;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo
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
                    .For<IDao<Bank>>()
                    .ImplementedBy<NHibernateStatelessDao<Bank>>(),

                Component
                    .For<IDao<StatisticModel>>()
                    .ImplementedBy<LuceneDao<StatisticModel>>(),

                Component
                    .For<IDao<LogModel>>()
                    .ImplementedBy<LuceneDao<LogModel>>(),

                Component
                    .For<INHibernateSessionFactoryFactory>()
                    .ImplementedBy<NHibernateSessionFactoryFactory>(),

                Component
                    .For<INHibernateSessionFactoryFactory>()
                    .ImplementedBy<Bosphorus.Dao.NHibernate.Common.Session.Factory.CacheDecorator>()
                    .IsDefault(),

                Component
                    .For<ILuceneDataProviderFactory>()
                    .ImplementedBy<LuceneDataProviderFactory>(),

                Component
                    .For<ILuceneDataProviderFactory>()
                    .ImplementedBy<Bosphorus.Dao.Lucene.Session.Provider.Factory.CacheDecorator>()
                    .IsDefault()
            );
        }
    }
}
