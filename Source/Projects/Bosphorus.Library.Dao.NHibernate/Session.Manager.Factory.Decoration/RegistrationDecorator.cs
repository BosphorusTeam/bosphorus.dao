using System.Collections;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Session.Manager.Repository;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory.Decoration
{
    public class RegistrationDecorator : INHibernateSessionManagerFactory
    {
        private readonly INHibernateSessionManagerFactory decorated;
        private readonly DefaultSessionManagerRepository sessionManagerRepository;

        public RegistrationDecorator(INHibernateSessionManagerFactory decorated, DefaultSessionManagerRepository sessionManagerRepository)
        {
            this.decorated = decorated;
            this.sessionManagerRepository = sessionManagerRepository;
        }

        public ISessionManager Build(IDictionary creationArguments)
        {
            ISessionManager sessionManager = decorated.Build(creationArguments);
            sessionManagerRepository.Register(sessionManager as NHibernateSessionManager);
            return sessionManager;
        }
    }
}
