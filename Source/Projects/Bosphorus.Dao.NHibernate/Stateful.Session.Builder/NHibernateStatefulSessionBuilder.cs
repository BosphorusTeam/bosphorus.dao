using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Bosphorus.Dao.NHibernate.Stateful.Session.Builder
{
    public class NHibernateStatefulSessionBuilder : AbstractSessionBuilder<NHibernateStatefulSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatefulSessionBuilder(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        protected override NHibernateStatefulSession ConstructInternal(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            ISession openSession = sessionFactory.OpenSession();
            NHibernateStatefulSession statefulSession = new NHibernateStatefulSession(openSession);
            return statefulSession;
        }

        protected override void DestructInternal(NHibernateStatefulSession session)
        {
            ISession adapted = session.GetNativeSession<ISession>();
            adapted.Flush();
            adapted.Close();
            adapted.Dispose();
        }
    }
}
