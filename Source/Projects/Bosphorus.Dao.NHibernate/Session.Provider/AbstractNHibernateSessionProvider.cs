using Bosphorus.Dao.Core.Session.Provider;
using NHibernate;
using ISession = Bosphorus.Dao.Core.Session.ISession;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    internal abstract class AbstractNHibernateSessionProvider<TSession> : AbstractSessionProvider<TSession> 
        where TSession : ISession
    {
        protected readonly ISessionFactory sessionFactory;

        protected AbstractNHibernateSessionProvider(string sessionAlias, ISessionFactory sessionFactory)
            : base(sessionAlias)
        {
            this.sessionFactory = sessionFactory;
        }

        public override void CloseSession(TSession session)
        {
            session.Dispose();
        }
    }
}