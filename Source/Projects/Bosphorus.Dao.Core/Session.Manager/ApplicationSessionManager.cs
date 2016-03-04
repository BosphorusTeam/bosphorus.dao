using System;
using System.Collections.Generic;
using Bosphorus.Common.Api.Context;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Application;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public class ApplicationSessionManager
    {
        private readonly ISessionProvider sessionProvider;
        private readonly IList<Type> sessionTypes;

        public ApplicationSessionManager(IContextListener<ApplicationContext> applicationContextListener, SessionDaoRegistry sessionDaoRegistry, ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
            sessionTypes = sessionDaoRegistry.SessionTypes;
            applicationContextListener.ContextStarted += ApplicationContextListenerOnContextStarted;
            applicationContextListener.ContextFinished += ApplicationContextListenerOnContextFinished;
        }

        private void ApplicationContextListenerOnContextStarted(object sender, ContextEventArgs<ApplicationContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                sessionProvider.Open(sessionType, SessionScope.Application);
            }
        }

        private void ApplicationContextListenerOnContextFinished(object sender, ContextEventArgs<ApplicationContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                sessionProvider.Close(sessionType, SessionScope.Application);
            }
        }
    }
}
