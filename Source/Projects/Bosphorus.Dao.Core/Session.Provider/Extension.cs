using System;
using System.Reflection;
using Bosphorus.Common.Clr.Symbol;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public static class Extension
    {
        private readonly static MethodInfo openMethodInfo;
        private readonly static MethodInfo currentMethodInfo;
        private readonly static MethodInfo closeMethodInfo;
        private readonly static Lazy<ExtensionConfiguration> configuration;

        static Extension()
        {
            openMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Open<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            currentMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Current<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            closeMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Close<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();

            configuration = IoC.staticContainer.Resolve<Lazy<ExtensionConfiguration>>();
        }

        public static ISession Open(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
        {
            Type defaultSessionType = configuration.Value.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericOpenMethodInfo = openMethodInfo.MakeGenericMethod(defaultSessionType);
            object session = genericOpenMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Open<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default) where TSession : ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            TSession result = extended.Open<TSession>(aliasName, currentSessionScope);
            return result;
        }

        public static ISession Current(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
        {
            Type defaultSessionType = configuration.Value.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericCurrentMethodInfo = currentMethodInfo.MakeGenericMethod(defaultSessionType);
            object session = genericCurrentMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Current<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default) where TSession : ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            TSession result = extended.Current<TSession>(aliasName, currentSessionScope);
            return result;
        }

        public static ISession Close(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
        {
            Type defaultSessionType = configuration.Value.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericCloseMethodInfo = closeMethodInfo.MakeGenericMethod(defaultSessionType);
            object session = genericCloseMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Close<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default) where TSession : ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            TSession result = extended.Close<TSession>(aliasName, currentSessionScope);
            return result;
        }

        private static SessionScope GetCurrentSessionScope(SessionScope sessionScope)
        {
            if (sessionScope != SessionScope.Default)
            {
                return sessionScope;
            }

            SessionScope result = configuration.Value.DefaultSessionScope;
            return result;
        }

    }
}
