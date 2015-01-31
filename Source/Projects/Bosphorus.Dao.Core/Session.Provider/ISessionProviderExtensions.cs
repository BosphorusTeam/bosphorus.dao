using System;
using Bosphorus.Container.Castle.Extra;

namespace Bosphorus.Dao.Core.Session.Provider
{
    public static class ISessionProviderExtensions
    {
        public static TSession Current<TSession>(this ISessionProvider<TSession> sessionProvider)
            where TSession : ISession
        {
            Func<object> factoryMethod = () => sessionProvider.OpenSession();
            var sessionCreateArguments = new { UsingFactoryMethod = factoryMethod, SessionAlias = sessionProvider.SessionAlias };
            TSession result = ServiceRegistry.Get<TSession>(sessionCreateArguments);
            return result;
        }
    }
}
