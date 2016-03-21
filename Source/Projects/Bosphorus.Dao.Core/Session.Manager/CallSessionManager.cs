using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Call;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class CallSessionManager: AbstractSessionManager<CallContext>
    {
        public CallSessionManager(IContextListener<CallContext> contextListener, SessionDaoRegistry sessionDaoRegistry, ISessionProvider sessionProvider) 
            : base(contextListener, sessionDaoRegistry, sessionProvider, SessionScope.Call)
        {
        }
    }
}
