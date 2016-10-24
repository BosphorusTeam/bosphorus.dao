using System;
using System.Reflection;
using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Session.Repository;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public static class Extension
    {
        private static IWindsorContainer container;
        private static readonly MethodInfo openMethodInfo;
        private static readonly MethodInfo currentMethodInfo;
        private static readonly MethodInfo closeMethodInfo;
        private static readonly Lazy<ExtensionConfiguration> configuration;

        public class Installer : IBosphorusInstaller
        {
            public void Install(IWindsorContainer instance, IConfigurationStore store)
            {
                container = instance;
            }
        }

        static Extension()
        {
            configuration = new Lazy<ExtensionConfiguration>(() => container.Resolve<ExtensionConfiguration>());
            openMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Open<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            currentMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Current<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            closeMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Close<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
        }

        public static ISession Open(this ISessionProvider extended, Type sessionType = null, SessionScope sessionScope = SessionScope.HostBounded, string aliasName = SessionAlias.Default)
        {
            Type currentSessionType = sessionType ?? configuration.Value.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericOpenMethodInfo = openMethodInfo.MakeGenericMethod(currentSessionType);
            object session = genericOpenMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static ISession Open<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.HostBounded, string aliasName = SessionAlias.Default)
            where TSession : class, ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            ISession result = extended.Open<TSession>(aliasName, currentSessionScope);
            return result;
        }

        public static ISession Current(this ISessionProvider extended, Type sessionType = null, SessionScope sessionScope = SessionScope.HostBounded, string aliasName = SessionAlias.Default)
        {
            Type currentSessionType = sessionType ?? configuration.Value.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericCurrentMethodInfo = currentMethodInfo.MakeGenericMethod(currentSessionType);
            object session = genericCurrentMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static ISession Current<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.HostBounded, string aliasName = SessionAlias.Default)
            where TSession : class, ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            ISession result = extended.Current<TSession>(aliasName, currentSessionScope);
            return result;
        }

        public static ISession Close(this ISessionProvider extended, Type sessionType = null, SessionScope sessionScope = SessionScope.HostBounded, string aliasName = SessionAlias.Default)
        {
            Type currentSessionType = sessionType ?? configuration.Value.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericCloseMethodInfo = closeMethodInfo.MakeGenericMethod(currentSessionType);
            object session = genericCloseMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static ISession Close<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.HostBounded, string aliasName = SessionAlias.Default)
            where TSession : class, ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            ISession result = extended.Close<TSession>(aliasName, currentSessionScope);
            return result;
        }

        private static SessionScope GetCurrentSessionScope(SessionScope sessionScope)
        {
            if (sessionScope != SessionScope.HostBounded)
            {
                return sessionScope;
            }

            SessionScope result = configuration.Value.DefaultSessionScope;
            return result;
        }

    }
}
