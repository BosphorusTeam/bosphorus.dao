using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public static class SessionProviderFactoryExtensions
    {
        public static ISessionProvider Build(this ISessionProviderFactory sessionProviderFactory)
        {
            ISessionProvider sessionProvider = sessionProviderFactory.Build(SessionAlias.Default);
            return sessionProvider;
        }
    }
}
