namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionProvider<TSession>
        where TSession: ISession
    {
        string SessionAlias { get; }

        TSession OpenSession();

        void CloseSession(TSession session);
    }
}
