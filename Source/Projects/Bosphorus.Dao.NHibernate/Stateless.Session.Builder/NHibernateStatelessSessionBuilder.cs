using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Stateless.Session.Builder
{
    public class NHibernateStatelessSessionBuilder: AbstractSessionBuilder<NHibernateStatelessSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatelessSessionBuilder(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        protected override NHibernateStatelessSession ConstructInternal(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            IStatelessSession nativeSession = sessionFactory.OpenStatelessSession();
            NHibernateStatelessSession result = new NHibernateStatelessSession(nativeSession);
            return result;
        }

        protected override void DestructInternal(NHibernateStatelessSession session)
        {
            IStatelessSession adapted = session.GetNativeSession<IStatelessSession>();
            adapted.Close();
        }
    }
}
