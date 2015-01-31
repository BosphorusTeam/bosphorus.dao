using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    internal class NHibernateStatefulSessionProvider : AbstractNHibernateSessionProvider<NHibernateStatefulSession>
    {
        public NHibernateStatefulSessionProvider(string sessionAlias, ISessionFactory sessionFactory)
            : base(sessionAlias, sessionFactory)
        {
        }

        public override NHibernateStatefulSession OpenSession()
        {
            ISession openSession = sessionFactory.OpenSession();
            NHibernateStatefulSession statefulSession = new NHibernateStatefulSession(openSession);
            return statefulSession;
        }
    }
}
        