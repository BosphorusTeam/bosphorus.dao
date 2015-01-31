using Bosphorus.Dao.Core.Session.Default.Provider;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Bosphorus.Dao.NHibernate.Dao;

namespace Bosphorus.Dao.NHibernate.Session.Default
{
    public class NHibernateStatelessDefaultSessionProvider : AbstractDefaultSessionProvider<NHibernateStatelessSession>
    {
        public NHibernateStatelessDefaultSessionProvider(ISessionProviderFactory<NHibernateStatelessSession> sessionProviderFactory) 
            : base(typeof(INHibernateStatelessDao<>), sessionProviderFactory)
        {
        }
    }
}
