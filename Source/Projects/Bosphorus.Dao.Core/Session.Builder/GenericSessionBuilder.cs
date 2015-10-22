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

        public TSession Construct<TSession>(string aliasName)
        {
            ISessionBuilder<TSession> sessionBuilder = container.Resolve<ISessionBuilder<TSession>>();
            TSession session = sessionBuilder.Construct(aliasName);
            return session;
        }

        public void Destruct<TSession>(TSession session)
        {
            ISessionBuilder<TSession> sessionBuilder = container.Resolve<ISessionBuilder<TSession>>();
            sessionBuilder.Destruct(session);
        }
    }
}
