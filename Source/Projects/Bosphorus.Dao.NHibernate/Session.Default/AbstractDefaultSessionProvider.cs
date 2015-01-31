using System;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Default.Provider;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;

namespace Bosphorus.Dao.NHibernate.Session.Default
{
    public abstract class AbstractDefaultSessionProvider<TSession> 
        : IDefaultSessionProvider where TSession : ISession
    {
        private readonly Type baseDaoType;
        private readonly ISessionProviderFactory<TSession> sessionProviderFactory;

        protected AbstractDefaultSessionProvider(Type baseDaoType, ISessionProviderFactory<TSession> sessionProviderFactory)
        {
            this.baseDaoType = baseDaoType;
            this.sessionProviderFactory = sessionProviderFactory;
        }

        public ISession Get<TModel>(IDao<TModel> dao, string sessionAlias)
        {
            Type daoType = dao.GetType();
            Type baseParameterizedType = baseDaoType.MakeGenericType(typeof (TModel));
            bool isAssignableFrom = baseParameterizedType.IsAssignableFrom(daoType);
            if (!isAssignableFrom)
            {
                return null;
            }

            ISessionProvider<TSession> sessionProvider = sessionProviderFactory.Build(sessionAlias);
            TSession session = sessionProvider.Current();
            return session;
        }
    }
}
