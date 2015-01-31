namespace Bosphorus.Dao.Core.Session.Provider
{
    public abstract class AbstractSessionProvider<TSession> : ISessionProvider<TSession>
        where TSession: ISession
    {
        private readonly string sessionAlias;

        protected AbstractSessionProvider(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
        }

        public string SessionAlias
        {
            get { return sessionAlias; }

        }
        public abstract TSession OpenSession();

        public abstract void CloseSession(TSession session);
    }
}