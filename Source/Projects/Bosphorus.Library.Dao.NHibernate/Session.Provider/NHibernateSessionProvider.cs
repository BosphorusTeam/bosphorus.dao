using Bosphorus.Dao.Core.Session.Provider;
using NHibernate;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    public class NHibernateSessionProvider: ISessionProvider
    {
        private readonly string sessionAlias;
        private readonly ISessionFactory sessionFactory;

        public NHibernateSessionProvider(string sessionAlias, ISessionFactory sessionFactory)
        {
            this.sessionAlias = sessionAlias;
            this.sessionFactory = sessionFactory;
        }

        internal ISessionFactory NativeSessionProvider
        {
            get { return sessionFactory; }
        }

        public string SessionAlias
        {
            get { return sessionAlias; }
        }

        public ISession OpenSession()
        {
            global::NHibernate.ISession openSession = sessionFactory.OpenSession();
            ISession session = new NHibernateSession(openSession);
            return session;
        }

        public void CloseSession(ISession session)
        {
            session.Dispose();
        }
    }
}
