using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider.Decoration.NullSafe
{
    public class NullSafeDecorator: ISessionProvider
    {
        private readonly ISessionProvider decorated;

        public NullSafeDecorator(ISessionProvider decorated)
        {
            this.decorated = decorated;
        }
        public TSession Open<TSession>(string aliasName, SessionScope sessionScope) 
            where TSession : class, ISession
        {
            TSession result = decorated.Open<TSession>(aliasName, sessionScope);
            return result;
        }

        public TSession Current<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession
        {
            TSession result = decorated.Current<TSession>(aliasName, sessionScope);
            if (result == null)
            {
                throw new SessionNotRegisteredException(aliasName, sessionScope);
            }

            return result;
        }

        public TSession Close<TSession>(string aliasName, SessionScope sessionScope)
            where TSession : class, ISession
        {
            TSession result = decorated.Close<TSession>(aliasName, sessionScope);
            return result;
        }

    }
}
