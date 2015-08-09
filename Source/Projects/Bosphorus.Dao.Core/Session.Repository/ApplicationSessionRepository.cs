using System.Collections.Generic;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public class ApplicationSessionRepository : ISessionRepository
    {
        private readonly IDictionary<string, ISession> repository;

        public ApplicationSessionRepository()
        {
            repository = new Dictionary<string, ISession>();
        }

        public void Put<TSession>(string aliasName, SessionScope sessionScope, TSession session) where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName);
            repository.Add(key, session);
        }

        public TSession Get<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName);
            ISession session;
            repository.TryGetValue(key, out session);
            return (TSession) session;
        }

        public TSession Remove<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName);
            TSession session = Get<TSession>(aliasName, sessionScope);
            repository.Remove(key);
            return session;
        }

        private string BuildKey<TSession>(string aliasName)
        {
            string typeName = typeof(TSession).FullName;
            string result = string.Format("{0} - {1}", aliasName, typeName);
            return result;
        }

    }
}