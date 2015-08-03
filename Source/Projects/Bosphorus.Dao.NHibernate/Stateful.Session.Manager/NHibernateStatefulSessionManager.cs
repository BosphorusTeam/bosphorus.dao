using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Session;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native;
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
