using System;
using Bosphorus.Dao.Core.Session.Builder.Decoration.Lazy;
using Castle.DynamicProxy;
using Castle.Windsor;

namespace Bosphorus.Dao.Core.Session.Builder
{
    public class GenericSessionBuilder
    {
        private readonly IWindsorContainer container;

        public GenericSessionBuilder(IWindsorContainer container)
        {
            this.container = container;
        }

        public ISession Construct<TSession>(string aliasName) 
            where TSession : class, ISession
        {
            ISessionBuilder<TSession> sessionBuilder = container.Resolve<ISessionBuilder<TSession>>();
            sessionBuilder = new LazyDecorator<TSession>(sessionBuilder);
            ISession session = sessionBuilder.Construct(aliasName);
            return session;
        }

        public void Destruct<TSession>(ISession session)
            where TSession : class, ISession
        {
            ISessionBuilder<TSession> sessionBuilder = container.Resolve<ISessionBuilder<TSession>>();
            sessionBuilder = new LazyDecorator<TSession>(sessionBuilder);
            sessionBuilder.Destruct(session);
        }
    }
}
