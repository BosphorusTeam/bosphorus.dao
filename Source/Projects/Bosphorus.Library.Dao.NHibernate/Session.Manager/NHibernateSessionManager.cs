using Bosphorus.Container.Castle.Extra;
using Bosphorus.Dao.Core.Session.Manager;
using NHibernate;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Session.Manager
{
    public class NHibernateSessionManager : AbstractSessionManager<NHibernateSession>, INHibernateSessionManager
    {
        private readonly string sessionAlias;
        private readonly ISessionFactory sessionManager;

        public NHibernateSessionManager(IServiceRegistry serviceRegistry, string sessionAlias, ISessionFactory sessionManager)
            : base(serviceRegistry)
        {
            this.sessionAlias = sessionAlias;
            this.sessionManager = sessionManager;
        }

        public ISessionFactory NativeSessionManager
        {
            get { return sessionManager; }
        }

        public override ISession OpenSession()
        {
            global::NHibernate.ISession openSession = sessionManager.OpenSession();
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
