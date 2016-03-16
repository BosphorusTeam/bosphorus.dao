using System;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public interface ISessionRepository
    {
        void Put<TSession>(string aliasName, SessionScope sessionScope, ISession session)
            where TSession : ISession;

        ISession Get<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : ISession;

        ISession Remove<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : ISession;
    }
}
