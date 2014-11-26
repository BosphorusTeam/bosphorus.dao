using System.Collections;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
{
    public static class NHibernateSessionManagerFactoryExtensions
    {
        public static ISessionManager Build(this INHibernateSessionManagerFactory extended, string sessionAlias)
        {
            IDictionary creationArguments = new Hashtable();
            creationArguments.Add("SessionAlias", sessionAlias);
            ISessionManager sessionManager = ((ISessionManagerFactory) extended).Build(creationArguments);

            return sessionManager;
        }

        public static ISessionManager Build(this INHibernateSessionManagerFactory extended)
        {
            ISessionManager sessionManager = extended.Build(SessionAlias.Default);
            return sessionManager;
        }
    }
}
