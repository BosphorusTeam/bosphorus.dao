using System;
using System.Collections.Generic;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public class ThreadSessionRepository : ISessionRepository
    {
        [ThreadStatic]
        private readonly static IDictionary<string, ISession> repository;

        static ThreadSessionRepository()
        {
            repository = new Dictionary<string, ISession>();
        }

        public void Put<TSession>(string aliasName, SessionScope sessionScope, TSession session) where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName, sessionScope);
            repository.Add(key, session);
        }

        public TSession Get<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName, sessionScope);
            ISession session;
            repository.TryGetValue(key, out session);
            return (TSession)session;
        }

        public TSession Remove<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName, sessionScope);
            TSession session = Get<TSession>(aliasName, sessionScope);
            repository.Remove(key);
            return session;
        }

        private string BuildKey<TSession>(string aliasName, SessionScope sessionScope)
        {
            string typeName = typeof(TSession).FullName;
            string result = $"{aliasName} - {sessionScope} - {typeName}";
            return result;
        }

    }
}