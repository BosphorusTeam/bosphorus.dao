namespace Bosphorus.Dao.Core.Session.Builder
{
    public interface ISessionManager<TSession>
    {
        TSession Construct(string aliasName);

        void Destruct(TSession session);
    }
}
