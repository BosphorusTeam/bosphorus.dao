using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionProvider
    {
        ISession Open<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession;

        ISession Current<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession;

        ISession Close<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession;
    }
}
