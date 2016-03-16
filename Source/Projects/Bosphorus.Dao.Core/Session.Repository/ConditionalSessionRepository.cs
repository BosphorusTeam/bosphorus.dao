using System.Collections.Generic;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public class ConditionalSessionRepository : ISessionRepository
    {
        private readonly IDictionary<SessionScope, ISessionRepository> repositoryDictionary;

        public ConditionalSessionRepository()
        {
            repositoryDictionary = new Dictionary<SessionScope, ISessionRepository>();
            repositoryDictionary.Add(SessionScope.Application, new ApplicationSessionRepository());
            repositoryDictionary.Add(SessionScope.Call, new ThreadSessionRepository());
            repositoryDictionary.Add(SessionScope.Thread, new ThreadSessionRepository());
        }

        public void Put<TSession>(string aliasName, SessionScope sessionScope, ISession session)
            where TSession : ISession
        {
            ISessionRepository sessionRepository = GetSessionRepository(sessionScope);
            sessionRepository.Put<TSession>(aliasName, sessionScope, session);
        }

        public ISession Get<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            ISessionRepository sessionRepository = GetSessionRepository(sessionScope);
            ISession session = sessionRepository.Get<TSession>(aliasName, sessionScope);
            return session;
        }

        public ISession Remove<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            ISessionRepository sessionRepository = GetSessionRepository(sessionScope);
            ISession session = sessionRepository.Remove<TSession>(aliasName, sessionScope);
            return session;
        }

        private ISessionRepository GetSessionRepository(SessionScope sessionScope)
        {
            if (!repositoryDictionary.ContainsKey(sessionScope))
            {
                throw new SessionRepositoryNotRegistered(sessionScope);
            }

            ISessionRepository sessionRepository = repositoryDictionary[sessionScope];
            return sessionRepository;
        }
    }
}