namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionProvider
    {
        ISession OpenSession();

        void CloseSession(ISession session);
    }
}
