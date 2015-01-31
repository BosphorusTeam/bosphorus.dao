using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    internal class NHibernateStatelessSessionProvider : AbstractNHibernateSessionProvider<NHibernateStatelessSession>
    {
        public NHibernateStatelessSessionProvider(string sessionAlias, ISessionFactory sessionFactory)
            : base(sessionAlias, sessionFactory)
        {
        }

        public override NHibernateStatelessSession OpenSession()
        {
            IStatelessSession nativeSession = sessionFactory.OpenStatelessSession();
            NHibernateStatelessSession result = new NHibernateStatelessSession(nativeSession);
            return result;
        }
    }
}
