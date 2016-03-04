using System;
using System.Collections.Generic;
using Bosphorus.Common.Api.Context;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Call;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class CallSessionManager
    {
        private readonly IList<Type> sessionTypes;
        private readonly ISessionProvider sessionProvider;

        public CallSessionManager(IContextListener<CallContext> callContextListener, SessionDaoRegistry sessionDaoRegistry, ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
            sessionTypes = sessionDaoRegistry.SessionTypes;
            callContextListener.ContextStarted += CallContextListenerOnContextStarted;
            callContextListener.ContextFinished += CallContextListenerOnContextFinished;
        }

        private void CallContextListenerOnContextStarted(object sender, ContextEventArgs<CallContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                sessionProvider.Open(sessionType, SessionScope.Call);
            }
        }

        private void CallContextListenerOnContextFinished(object sender, ContextEventArgs<CallContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                sessionProvider.Close(sessionType, SessionScope.Call);
            }
        }

    }
}
