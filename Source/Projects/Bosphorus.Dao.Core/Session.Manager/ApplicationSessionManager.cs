using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Application;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class ApplicationSessionManager: AbstractSessionManager<ApplicationContext>
    {
        public ApplicationSessionManager(IContextListener<ApplicationContext> contextListener, SessionDaoRegistry sessionDaoRegistry, ISessionProvider sessionProvider) 
            : base(contextListener, sessionDaoRegistry, sessionProvider, SessionScope.Application)
        {
        }
    }
}
