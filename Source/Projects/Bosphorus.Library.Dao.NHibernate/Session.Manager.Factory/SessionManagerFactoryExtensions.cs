﻿using System.Collections;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
{
    internal static class SessionManagerFactoryExtensions
    {
        public static ISessionManager Build(this ISessionManagerFactory extended, string sessionAlias)
        {
            IDictionary creationArguments = new Hashtable();
            creationArguments.Add("SessionAlias", sessionAlias);
            ISessionManager sessionManager = extended.Build(creationArguments);

            return sessionManager;
        }

        public static ISessionManager Build(this ISessionManagerFactory extended)
        {
            ISessionManager sessionManager = extended.Build(SessionAlias.Default);
            return sessionManager;
        }
    }
}
