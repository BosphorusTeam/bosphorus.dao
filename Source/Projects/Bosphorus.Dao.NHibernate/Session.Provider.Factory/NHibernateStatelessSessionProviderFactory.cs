using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public class NHibernateStatelessSessionProviderFactory : ISessionProviderFactory<NHibernateStatelessSession>
    {
        private readonly INHibernateSessionFactoryBuilder inHibernateSessionFactoryBuilder;

        public NHibernateStatelessSessionProviderFactory(INHibernateSessionFactoryBuilder inHibernateSessionFactoryBuilder)
        {
            this.inHibernateSessionFactoryBuilder = inHibernateSessionFactoryBuilder;
        }

        public ISessionProvider<NHibernateStatelessSession> Build(string sessionAlias)
        {
            ISessionFactory sessionFactory = inHibernateSessionFactoryBuilder.Build(sessionAlias);
            NHibernateStatelessSessionProvider sessionProvider = new NHibernateStatelessSessionProvider(sessionAlias, sessionFactory);
            return sessionProvider;
        }
    }
}
