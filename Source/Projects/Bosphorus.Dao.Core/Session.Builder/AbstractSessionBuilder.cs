namespace Bosphorus.Dao.Core.Session.Builder
{
    public abstract class AbstractSessionBuilder<TSession> : ISessionBuilder<TSession> 
        where TSession : class, ISession
    {
        public ISession Construct(string aliasName)
        {
            TSession typedSession = ConstructInternal(aliasName);
            return typedSession;
        }

        protected abstract TSession ConstructInternal(string aliasName);

        public void Destruct(ISession session)
        {
            TSession typedSession = session as TSession;
            DestructInternal(typedSession);
        }

        protected abstract void DestructInternal(TSession typedSession);
    }
}