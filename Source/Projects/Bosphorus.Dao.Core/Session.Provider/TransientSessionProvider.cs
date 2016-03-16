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

        public ISession Open<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession
        {
            ISession session = genericSessionBuilder.Construct<TSession>(aliasName);
            sessionRepository.Put<TSession>(aliasName, sessionScope, session);
            return session;
        }

        public ISession Current<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession
        {
            ISession session = sessionRepository.Get<TSession>(aliasName, sessionScope);
            return session;
        }

        public ISession Close<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession
        {
            ISession session = sessionRepository.Remove<TSession>(aliasName, sessionScope);
            genericSessionBuilder.Destruct<TSession>(session);
            return session;
        }
    }
}