using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionProvider
    {
        TSession Open<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession;

        TSession Current<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession;

        TSession Close<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession;
    }
}
