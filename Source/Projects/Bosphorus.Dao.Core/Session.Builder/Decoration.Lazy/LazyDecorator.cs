using System;

namespace Bosphorus.Dao.Core.Session.Builder.Decoration.Lazy
{
    internal class LazyDecorator<TSession> : ISessionBuilder<TSession> 
        where TSession : class, ISession
    {
        private readonly ISessionBuilder<TSession> decorated;

        public LazyDecorator(ISessionBuilder<TSession> decorated)
        {
            this.decorated = decorated;
        }

        public ISession Construct(string aliasName)
        {
            Lazy<ISession> inner = new Lazy<ISession>(() => decorated.Construct(aliasName));
            LazySession lazySession = new LazySession(inner);
            return lazySession;
        }

        public void Destruct(ISession session)
        {
            LazySession lazySession = (LazySession) session;
            Lazy<ISession> inner = lazySession.Inner;
            if (!inner.IsValueCreated)
            {
                return;
            }

            ISession decoratedSession = lazySession.Inner.Value;
            decorated.Destruct(decoratedSession);
        }
    }
}
