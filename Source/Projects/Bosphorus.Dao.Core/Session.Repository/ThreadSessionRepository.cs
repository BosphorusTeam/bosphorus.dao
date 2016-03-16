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

        public void Put<TSession>(string aliasName, SessionScope sessionScope, ISession session) 
            where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName, sessionScope);
            repository.Add(key, session);
        }

        public ISession Get<TSession>(string aliasName, SessionScope sessionScope) 
            where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName, sessionScope);
            ISession session;
            repository.TryGetValue(key, out session);
            return session;
        }

        public ISession Remove<TSession>(string aliasName, SessionScope sessionScope) 
            where TSession : ISession
        {
            string key = BuildKey<TSession>(aliasName, sessionScope);
            ISession session = Get<TSession>(aliasName, sessionScope);
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