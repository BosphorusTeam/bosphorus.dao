namespace Bosphorus.Dao.Core.Session.Manager
{
    public interface ISessionManager
    {
        ISession OpenSession();

        ISession Current { get; }

        void CloseSession(ISession session);
    }
}
