using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Bosphorus.Library.Dao.NHibernate.Model.Session.Configurator;
using Bosphorus.Library.Dao.NHibernate.Model.Session;
using Bosphorus.Library.Dao.Core.Model.Session;

namespace Bosphorus.Library.Dao.RI.Dao.NHibernate.Session
{
    public class SessionFactory
    {
        private const string CashFlow = "CashFlow";
        private static INHibernateSessionFactory sessionFactory1;
        private static INHibernateSessionFactory sessionFactory2;

        static SessionFactory()
        {
            Assembly assembly = typeof(SessionFactory).Assembly;
            string resourceName = "Bosphorus.Library.Dao.RI.Dao.NHibernate.Session.CashFlow.cfg.xml";
            ISessionFactoryConfigurator configurator = new ResourceConfigurator(assembly, resourceName);
            sessionFactory1 = new NHibernateSessionFactory(configurator);
            sessionFactory2 = new NHibernateSessionFactory(configurator);
        }

        public static NHibernateSessionAdapter CashFlowSession
        {
            get { return new NHibernateSessionAdapter(sessionFactory1, CashFlow); }
        }

        public static NHibernateSessionAdapter TempSession
        {
            get { return new NHibernateSessionAdapter(sessionFactory2, "Temp"); }
        }
    }
}
