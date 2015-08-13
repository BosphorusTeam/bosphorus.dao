using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Stateless.Session.Manager
{
    public class NHibernateStatelessSessionManager: ISessionManager<NHibernateStatelessSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatelessSessionManager(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        public NHibernateStatelessSession Construct(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            IStatelessSession nativeSession = sessionFactory.OpenStatelessSession();
            NHibernateStatelessSession result = new NHibernateStatelessSession(nativeSession);
            return result;
        }

        public void Destruct(NHibernateStatelessSession session)
        {
            IStatelessSession adapted = session.InnerSession;
            adapted.Close();
        }
    }
}
