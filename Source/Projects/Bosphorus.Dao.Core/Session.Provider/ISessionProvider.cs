using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public interface ISessionProvider
    {
        TSession Open<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : ISession;

        TSession Current<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : ISession;

        TSession Close<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : ISession;
    }
}
