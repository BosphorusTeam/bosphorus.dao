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
        private readonly static Type defaultSessionType;
        private readonly static ExtensionConfiguration configuration;

        static Extension()
        {
            openMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Open<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            currentMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Current<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();
            closeMethodInfo = Reflection<ISessionProvider>.GetMethodInfo(x => x.Close<ISession>(null, SessionScope.Null)).GetGenericMethodDefinition();

            configuration = IoC.staticContainer.Resolve<ExtensionConfiguration>();
            defaultSessionType = configuration.DefaultSessionType;
        }

        public static ISession Open(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Application, string aliasName = SessionAlias.Default)
        {
            MethodInfo genericOpenMethodInfo = openMethodInfo.MakeGenericMethod(defaultSessionType);
            object session = genericOpenMethodInfo.Invoke(extended, new object[] { aliasName, sessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Open<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Application, string aliasName = SessionAlias.Default) where TSession : ISession
        {
            TSession result = extended.Open<TSession>(aliasName, sessionScope);
            return result;
        }

        public static ISession Current(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Null, string aliasName = SessionAlias.Default)
        {
            SessionScope currentSessionScope = sessionScope == SessionScope.Null ? configuration.DefaultSessionScope : sessionScope;
            MethodInfo genericCurrentMethodInfo = currentMethodInfo.MakeGenericMethod(defaultSessionType);
            object session = genericCurrentMethodInfo.Invoke(extended, new object[] { aliasName, sessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Current<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Application, string aliasName = SessionAlias.Default) where TSession : ISession
        {
            TSession result = extended.Open<TSession>(aliasName, sessionScope);
            return result;
        }

        public static ISession Close(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Application, string aliasName = SessionAlias.Default)
        {
            MethodInfo genericCloseMethodInfo = closeMethodInfo.MakeGenericMethod(defaultSessionType);
            object session = genericCloseMethodInfo.Invoke(extended, new object[] { aliasName, sessionScope });
            ISession result = (ISession)session;
            return result;
        }

        public static TSession Close<TSession>(this ISessionProvider extended, SessionScope sessionScope = SessionScope.Application, string aliasName = SessionAlias.Default) where TSession : ISession
        {
            TSession result = extended.Close<TSession>(aliasName, sessionScope);
            return result;
        }

    }
}
