namespace Bosphorus.Dao.Core.Session.Manager
{
    public interface ISessionManager
    {
        string SessionAlias { get; }

        ISession OpenSession();

        ISession Current { get; }

        void CloseSession(ISession session);
    }
}
