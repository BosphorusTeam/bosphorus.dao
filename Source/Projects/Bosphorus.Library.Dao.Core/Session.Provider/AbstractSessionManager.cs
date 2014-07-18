using Bosphorus.Container.Castle.Registry;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public abstract class AbstractSessionManager : ISessionManager
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly string sessionAlias;

        protected AbstractSessionManager(IServiceRegistry serviceRegistry, string sessionAlias)
        {
            this.serviceRegistry = serviceRegistry;
            this.sessionAlias = sessionAlias;
        }

        public string SessionAlias
        {
            get { return sessionAlias; }
        }

        public abstract ISession OpenSession();

        public ISession Current
        {
            get
            {
                var argument = new {SessionAlias};
                return serviceRegistry.Get<ISession>(argument);
            }
        }

        public abstract void CloseSession(ISession session);
    }
}