using Bosphorus.Container.Castle.Extra;
using NHibernate;
using NHibernate.Context;

namespace Bosphorus.Dao.NHibernate.Session
{
    public class NHibernateCurrentSessionContext : ICurrentSessionContext
    {
        public NHibernateCurrentSessionContext()
        {
            
        }

        public ISession CurrentSession()
        {
            NHibernateSession session = (NHibernateSession) ServiceRegistry.Get<ISession>();
            return session.InnerSession;
        }
    }
}
