using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class SessionManager
    {
        private readonly IWindsorContainer container;

        public SessionManager(IWindsorContainer container)
        {
            this.container = container;
        }

        public TSession Construct<TSession>(string aliasName)
        {
            ISessionManager<TSession> sessionManager = container.Resolve<ISessionManager<TSession>>();
            TSession session = sessionManager.Construct(aliasName);
            return session;
        }

        public void Destruct<TSession>(TSession session)
        {
            ISessionManager<TSession> sessionManager = container.Resolve<ISessionManager<TSession>>();
            sessionManager.Destruct(session);
        }
    }
}
