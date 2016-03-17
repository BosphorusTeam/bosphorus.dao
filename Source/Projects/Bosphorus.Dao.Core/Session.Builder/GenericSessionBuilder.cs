using System;
using Bosphorus.Dao.Core.Transaction;
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
            ISession lazySession = new LazySession(new Lazy<ISession>(() =>
            {
                ISessionBuilder<TSession> sessionBuilder = container.Resolve<ISessionBuilder<TSession>>();
                ISession session = sessionBuilder.Construct(aliasName);
                return session;
            }));

            return lazySession;
        }

        public void Destruct<TSession>(ISession session)
            where TSession : class, ISession
        {
            LazySession lazySession = (LazySession) session;
            if (!lazySession.inner.IsValueCreated)
            {
                return;
            }

            ISession innerSession = lazySession.inner.Value;
            ISessionBuilder<TSession> sessionBuilder = container.Resolve<ISessionBuilder<TSession>>();
            sessionBuilder.Destruct(innerSession);
        }
    }

    public class LazySession : ISession
    {
        public readonly Lazy<ISession> inner;

        public LazySession(Lazy<ISession> inner)
        {
            this.inner = inner;
        }

        public void Dispose()
        {
            inner.Value.Dispose();
        }

        public object NativeSession => inner.Value.NativeSession;

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            return inner.Value.NewTransaction(isolationLevel);
        }
    }
}
