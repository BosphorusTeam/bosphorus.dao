using Bosphorus.Container.Castle.Extra;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public abstract class AbstractSessionManager<TSession> : ISessionManager
        where TSession: ISession
    {
        private readonly IServiceRegistry serviceRegistry;

        protected AbstractSessionManager(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public abstract ISession OpenSession();

        public ISession Current
        {
            get
            {
                var argument = BuildSessionManagerCreationArguments();
                TSession session = serviceRegistry.Get<TSession>(argument);
                return session;
            }
        }

        protected abstract object BuildSessionManagerCreationArguments();

        public abstract void CloseSession(ISession session);
    }
}