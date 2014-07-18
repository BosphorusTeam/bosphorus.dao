using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session.Provider;
using NHibernate;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    public class NHibernateSessionManager: AbstractSessionManager
    {
        private readonly string sessionAlias;
        private readonly ISessionFactory sessionFactory;

        public NHibernateSessionManager(IServiceRegistry serviceRegistry, string sessionAlias, ISessionFactory sessionFactory)
            : base(serviceRegistry)
        {
            this.sessionAlias = sessionAlias;
            this.sessionFactory = sessionFactory;
        }

        internal ISessionFactory NativeSessionProvider
        {
            get { return sessionFactory; }
        }

        public override string SessionAlias
        {
            get { return sessionAlias; }
        }

        public override ISession OpenSession()
        {
            global::NHibernate.ISession openSession = sessionFactory.OpenSession();
            ISession session = new NHibernateSession(openSession);
            return session;
        }

        public override void CloseSession(ISession session)
        {
            session.Dispose();
        }
    }
}
