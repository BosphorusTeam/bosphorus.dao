namespace Bosphorus.Dao.Core.Session.Builder
{
    public interface ISessionBuilder<TSession>
        where TSession: class, ISession
    {
        TSession Construct(string aliasName);

        void Destruct(TSession session);
    }
}
