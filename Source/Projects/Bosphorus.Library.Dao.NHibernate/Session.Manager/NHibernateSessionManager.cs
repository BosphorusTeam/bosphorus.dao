using Bosphorus.Container.Castle.Registry;
using Bosphorus.Dao.Core.Session.Manager;
using Castle.Windsor;
using NHibernate;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Session.Manager
{
    public class NHibernateSessionManager : AbstractSessionManager<NHibernateSession>, INHibernateSessionManager
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

        public override ISession OpenSession()
        {
            global::NHibernate.ISession openSession = sessionFactory.OpenSession();
            ISession session = new NHibernateSession(openSession);
            return session;
        }

        protected override object BuildSessionManagerCreationArguments()
        {
            var creationArguments = new {SessionAlias = sessionAlias};
            return creationArguments;
        }

        public override void CloseSession(ISession session)
        {
            session.Dispose();
        }
    }
}
