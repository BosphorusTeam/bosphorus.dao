using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public class TransientSessionProvider : ISessionProvider
    {
        private readonly GenericSessionBuilder genericSessionBuilder;
        private readonly ISessionRepository sessionRepository;

        public TransientSessionProvider(GenericSessionBuilder genericSessionBuilder, ISessionRepository sessionRepository)
        {
            this.genericSessionBuilder = genericSessionBuilder;
            this.sessionRepository = sessionRepository;
        }

        public TSession Open<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            TSession session = genericSessionBuilder.Construct<TSession>(aliasName);
            sessionRepository.Put(aliasName, sessionScope, session);
            return session;
        }

        public TSession Current<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            TSession session = sessionRepository.Get<TSession>(aliasName, sessionScope);
            return session;
        }

        public TSession Close<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            TSession session = sessionRepository.Remove<TSession>(aliasName, sessionScope);
            genericSessionBuilder.Destruct(session);
            return session;
        }
    }
}