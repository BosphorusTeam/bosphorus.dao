namespace Bosphorus.Dao.Core.Session.Builder
{
    public interface ISessionBuilder<TSession>
    {
        TSession Construct(string aliasName);

        void Destruct(TSession session);
    }
}
