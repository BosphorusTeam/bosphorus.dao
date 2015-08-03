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
            repositoryDictionary.Add(SessionScope.Thread, new ThreadSessionRepository());
        }

        public void Put<TSession>(string aliasName, SessionScope sessionScope, TSession session) where TSession : ISession
        {
            ISessionRepository sessionRepository = repositoryDictionary[sessionScope];
            sessionRepository.Put(aliasName, sessionScope, session);
        }

        public TSession Get<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            ISessionRepository sessionRepository = repositoryDictionary[sessionScope];
            TSession session = sessionRepository.Get<TSession>(aliasName, sessionScope);
            return session;
        }

        public TSession Remove<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            ISessionRepository sessionRepository = repositoryDictionary[sessionScope];
            TSession session = sessionRepository.Remove<TSession>(aliasName, sessionScope);
            return session;
        }
    }
}