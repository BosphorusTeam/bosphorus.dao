namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionProvider
    {
        string SessionAlias { get; }

        ISession OpenSession();

        void CloseSession(ISession session);
    }
}
