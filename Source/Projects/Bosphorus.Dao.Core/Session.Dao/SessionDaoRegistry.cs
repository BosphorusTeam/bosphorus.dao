using System;
using System.Collections.Generic;

namespace Bosphorus.Dao.Core.Session.Dao
{
    public class SessionDaoRegistry
    {
        private readonly IList<Type> sessionTypes;
        private readonly IDictionary<Type, Type> daoSessionDictionary;

        public SessionDaoRegistry(IList<ISessionDaoRegisterer> sessionDaoRegisterers)
        {
            sessionTypes = new List<Type>();
            daoSessionDictionary = new Dictionary<Type, Type>();
            foreach (ISessionDaoRegisterer sessionDaoRegisterer in sessionDaoRegisterers)
            {
                sessionDaoRegisterer.Register(this);
            }
        }

        public void Register<TSession>(params Type[] daoTypes) where TSession : ISession
        {
            Type sessionType = typeof (TSession);

            sessionTypes.Add(sessionType);
            foreach (Type daoType in daoTypes)
            {
                daoSessionDictionary.Add(daoType, sessionType);
            }
        }

        public IList<Type> SessionTypes => sessionTypes;

        public Type GetSessionType(Type daoType)
        {
            Type daoGenericType = daoType.GetGenericTypeDefinition();
            Type sessionType = daoSessionDictionary[daoGenericType];
            return sessionType;
        }
    }
}