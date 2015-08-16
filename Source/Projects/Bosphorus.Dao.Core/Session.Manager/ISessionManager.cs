namespace Bosphorus.Dao.Core.Session.Manager
{
    public interface ISessionManager<TSession>
    {
        TSession Construct(string aliasName);

        void Destruct(TSession session);
    }
}
