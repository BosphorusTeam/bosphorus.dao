using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public class NHibernateStatefulSessionProviderFactory : ISessionProviderFactory<NHibernateStatefulSession>
    {
        private readonly INHibernateSessionFactoryBuilder nhibernateSessionFactoryBuilder;

        public NHibernateStatefulSessionProviderFactory(INHibernateSessionFactoryBuilder nhibernateSessionFactoryBuilder)
        {
            this.nhibernateSessionFactoryBuilder = nhibernateSessionFactoryBuilder;
        }

        public ISessionProvider<NHibernateStatefulSession> Build(string sessionAlias)
        {
            ISessionFactory sessionFactory = nhibernateSessionFactoryBuilder.Build(sessionAlias);
            NHibernateStatefulSessionProvider sessionProvider = new NHibernateStatefulSessionProvider(sessionAlias, sessionFactory);
            return sessionProvider;
        }
    }
}
