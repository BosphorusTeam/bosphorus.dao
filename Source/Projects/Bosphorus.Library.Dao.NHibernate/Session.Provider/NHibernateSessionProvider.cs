using Bosphorus.Dao.Core.Session.Provider;
using NHibernate;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    public class NHibernateSessionProvider: ISessionProvider
    {
        private readonly ISessionFactory sessionFactory;

        public NHibernateSessionProvider(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
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
