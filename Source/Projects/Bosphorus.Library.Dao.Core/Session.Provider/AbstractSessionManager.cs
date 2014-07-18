using Bosphorus.Container.Castle.Registry;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public abstract class AbstractSessionManager : ISessionManager
    {
        private readonly IServiceRegistry serviceRegistry;

        protected AbstractSessionManager(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public abstract string SessionAlias { get; }

        public abstract ISession OpenSession();

        public ISession Current
        {
            get { return serviceRegistry.Get<ISession>(); }
        }

        public abstract void CloseSession(ISession session);
    }
}