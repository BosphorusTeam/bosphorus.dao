using System;
using System.Collections.Generic;
using Bosphorus.Common.Api.Context;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Manager
{
    public abstract class AbstractSessionManager<TContext>
        where TContext: IContext
    {
        private readonly IList<Type> sessionTypes;
        private readonly ISessionProvider sessionProvider;
        private readonly SessionScope sessionScope;

        protected AbstractSessionManager(IContextListener<TContext> contextListener, SessionDaoRegistry sessionDaoRegistry, ISessionProvider sessionProvider, SessionScope sessionScope)
        {
            this.sessionProvider = sessionProvider;
            this.sessionScope = sessionScope;
            sessionTypes = sessionDaoRegistry.SessionTypes;
            contextListener.ContextStarted += ContextListenerOnContextStarted;
            contextListener.ContextFailed += ContextListenerOnContextFailed;
            contextListener.ContextSuccessful += ContextListenerOnContextSuccessful;
            contextListener.ContextFinished += ContextListenerOnContextFinished;
        }

        private void ContextListenerOnContextStarted(object sender, ContextEventArgs<TContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                sessionProvider.Open(sessionType, sessionScope);
            }
        }

        private void ContextListenerOnContextFailed(object sender, ContextEventArgs<TContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                ISession session = sessionProvider.Current(sessionType, sessionScope);
                session.Clear();
            }
        }

        private void ContextListenerOnContextSuccessful(object sender, ContextEventArgs<TContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                ISession session = sessionProvider.Current(sessionType, sessionScope);
                session.Flush();
            }
        }

        private void ContextListenerOnContextFinished(object sender, ContextEventArgs<TContext> contextEventArgs)
        {
            foreach (Type sessionType in sessionTypes)
            {
                sessionProvider.Close(sessionType, sessionScope);
            }
        }

    }
}
