﻿using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Bosphorus.Dao.NHibernate.Stateful.Session.Builder
{
    public class NHibernateStatefulSessionBuilder : AbstractSessionBuilder<NHibernateStatefulSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatefulSessionBuilder(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        protected override NHibernateStatefulSession ConstructInternal(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            ISession adapted = sessionFactory.OpenSession();
            NHibernateStatefulSession session = new NHibernateStatefulSession(adapted);
            return session;
        }

        protected override void DestructInternal(NHibernateStatefulSession session)
        {
            var adapted = session.GetNativeSession<ISession>();
            adapted.Close();
            adapted.Dispose();
        }
    }
}
