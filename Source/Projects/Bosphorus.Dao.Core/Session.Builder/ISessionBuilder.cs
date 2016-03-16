namespace Bosphorus.Dao.Core.Session.Builder
{
    public interface ISessionBuilder<TSession>
        where TSession: class, ISession
    {
        ISession Construct(string aliasName);

        void Destruct(ISession session);
    }
}
