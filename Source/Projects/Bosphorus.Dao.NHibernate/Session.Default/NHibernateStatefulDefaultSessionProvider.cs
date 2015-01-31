using Bosphorus.Dao.Core.Session.Default.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Dao;

namespace Bosphorus.Dao.NHibernate.Session.Default
{
    public class NHibernateStatefulDefaultSessionProvider : AbstractDefaultSessionProvider<NHibernateStatefulSession>
    {
        public NHibernateStatefulDefaultSessionProvider(ISessionProviderFactory<NHibernateStatefulSession> sessionProviderFactory) 
            : base(typeof(INHibernateStatefulDao<>),  sessionProviderFactory)
        {
        }
    }
}
