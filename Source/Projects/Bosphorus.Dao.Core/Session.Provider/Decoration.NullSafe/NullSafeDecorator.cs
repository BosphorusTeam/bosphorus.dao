using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.Core.Session.Repository.Decorations.NullSafe
{
    public class NullSafeDecorator: ISessionProvider
    {
        private readonly ISessionProvider decorated;

        public NullSafeDecorator(ISessionProvider decorated)
        {
            this.decorated = decorated;
        }
        public TSession Open<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            TSession result = decorated.Open<TSession>(aliasName, sessionScope);
            return result;
        }

        public TSession Current<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            TSession result = decorated.Current<TSession>(aliasName, sessionScope);
            if (result == null)
            {
                throw new SessionNotRegisteredException(aliasName, sessionScope);
            }

            return result;
        }

        public TSession Close<TSession>(string aliasName, SessionScope sessionScope) where TSession : ISession
        {
            TSession result = decorated.Close<TSession>(aliasName, sessionScope);
            return result;
        }

    }
}
