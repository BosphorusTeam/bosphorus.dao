using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Dao
{
    public class SessionDaoRegistry
    {
        private readonly IList<Type> sessionTypes;
        private readonly IDictionary<Type, Type> daoSessionDictionary;

        public SessionDaoRegistry(IList<ISessionDaoRegisterer> sessionDaoRegistrars)
        {
            sessionTypes = new List<Type>();
            daoSessionDictionary = new Dictionary<Type, Type>();
            foreach (ISessionDaoRegisterer sessionDaoRegisterer in sessionDaoRegistrars)
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

        public Type GetSessionType(Type daoGenericType)
        {
            if (!daoSessionDictionary.ContainsKey(daoGenericType))
            {
                throw new SessionTypeNotRegisteredException(daoGenericType);
            }
            Type sessionType = daoSessionDictionary[daoGenericType];
            return sessionType;
        }
    }
}
