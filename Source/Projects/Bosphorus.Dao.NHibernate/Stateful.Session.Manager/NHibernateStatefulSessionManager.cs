using System;
using System.Collections.Generic;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Stateful.Session.Manager
{
    public class NHibernateStatefulSessionManager : ISessionManager<NHibernateStatefulSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatefulSessionManager(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        public NHibernateStatefulSession Construct(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            ISession openSession = sessionFactory.OpenSession();
            NHibernateStatefulSession statefulSession = new NHibernateStatefulSession(openSession);
            return statefulSession;
        }

        public void Destruct(NHibernateStatefulSession session)
        {
            ISession adapted = session.InnerSession;
            adapted.Flush();
            adapted.Close();
            adapted.Dispose();
        }
    }
}
