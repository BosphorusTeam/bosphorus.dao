using System;
using System.Collections.Generic;
using Bosphorus.Common.Application;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Repository;
using Castle.MicroKernel;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public class ExtensionConfiguration
    {
        private readonly Host host;
        private static readonly IDictionary<Host, SessionScope> hostDefaultSessionScopes;

        static ExtensionConfiguration()
        {
            hostDefaultSessionScopes = new Dictionary<Host, SessionScope>();
            hostDefaultSessionScopes.Add(Host.Console, SessionScope.Application);
            hostDefaultSessionScopes.Add(Host.WinForm, SessionScope.Application);
            hostDefaultSessionScopes.Add(Host.Test, SessionScope.Application);
            hostDefaultSessionScopes.Add(Host.IIS, SessionScope.Call);
            hostDefaultSessionScopes.Add(Host.WCF, SessionScope.Call);
        }

        public Type DefaultSessionType { get; }

        public SessionScope DefaultSessionScope => hostDefaultSessionScopes[host];

        public ExtensionConfiguration(IWindsorContainer container, SessionDaoRegistry sessionDaoRegistry, Host host)
        {
            this.host = host;
            this.DefaultSessionType = GetDefaultSessionType(container, sessionDaoRegistry);
        }

        private static Type GetDefaultSessionType(IWindsorContainer container, SessionDaoRegistry sessionDaoRegistry)
        {
            //TODO: Bu kodu daha güzel yaz.. Örneğin; container'a extension method yazabilirsin
            IHandler handler = container.Kernel.GetHandler(typeof (IDao<>));
            if (handler == null)
            {
                return null;
            }

            Type installedDaoGenericType = handler.ComponentModel.Implementation;
            Type sessionType = sessionDaoRegistry.GetSessionType(installedDaoGenericType);
            return sessionType;
        }

    }
}
