using System;
using System.Reflection;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public static class Extension
    {
        private readonly static MethodInfo openMethodInfo;
        private readonly static MethodInfo currentMethodInfo;
        private readonly static MethodInfo closeMethodInfo;
        private readonly static ExtensionConfiguration configuration;

        static Extension()
        {
            openMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Open<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            currentMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Current<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            closeMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Close<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();

            configuration = ContainerHolder.Current.Resolve<ExtensionConfiguration>();
        }

        public static ISession Open(this ISessionProvider extended, Type sessionType = null, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
        {
            Type currentSessionType = sessionType ?? configuration.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericOpenMethodInfo = openMethodInfo.MakeGenericMethod(currentSessionType);
            object session = genericOpenMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Open<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
            where TSession : class, ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            TSession result = extended.Open<TSession>(aliasName, currentSessionScope);
            return result;
        }

        public static ISession Current(this ISessionProvider extended, Type sessionType = null, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
        {
            Type currentSessionType = sessionType ?? configuration.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericCurrentMethodInfo = currentMethodInfo.MakeGenericMethod(currentSessionType);
            object session = genericCurrentMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Current<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
            where TSession : class, ISession
        {
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            TSession result = extended.Current<TSession>(aliasName, currentSessionScope);
            return result;
        }

        public static ISession Close(this ISessionProvider extended, Type sessionType = null, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
        {
            Type currentSessionType = sessionType ?? configuration.DefaultSessionType;
            SessionScope currentSessionScope = GetCurrentSessionScope(sessionScope);
            MethodInfo genericCloseMethodInfo = closeMethodInfo.MakeGenericMethod(currentSessionType);
            object session = genericCloseMethodInfo.Invoke(extended, new object[] { aliasName, currentSessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Close<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Default, string aliasName = SessionAlias.Default)
            where TSession : class, ISession
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

            SessionScope result = configuration.DefaultSessionScope;
            return result;
        }

    }
}
