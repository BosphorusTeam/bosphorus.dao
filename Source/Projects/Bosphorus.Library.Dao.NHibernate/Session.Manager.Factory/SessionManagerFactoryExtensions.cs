using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
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
