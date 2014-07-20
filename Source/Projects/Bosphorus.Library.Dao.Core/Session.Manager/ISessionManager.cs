namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionManager
    {
        string SessionAlias { get; }

        ISession OpenSession();

        ISession Current { get; }

        void CloseSession(ISession session);
    }
}
