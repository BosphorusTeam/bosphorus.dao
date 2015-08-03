using System;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public interface ISessionRepository
    {
        void Put<TSession>(String aliasName, SessionScope sessionScope, TSession session)
            where TSession : ISession;

        TSession Get<TSession>(String aliasName, SessionScope sessionScope)
            where TSession : ISession;

        TSession Remove<TSession>(String aliasName, SessionScope sessionScope)
            where TSession : ISession;
    }
}
