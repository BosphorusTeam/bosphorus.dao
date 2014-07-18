using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public static class SessionManagerFactoryExtensions
    {
        public static ISessionManager Build(this ISessionManagerFactory sessionManagerFactory)
        {
            ISessionManager sessionManager = sessionManagerFactory.Build(SessionAlias.Default);
            return sessionManager;
        }
    }
}
