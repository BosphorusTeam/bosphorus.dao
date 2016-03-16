using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using NHibernate;
using ISession = NHibernate.ISession;

namespace Bosphorus.Dao.NHibernate.Stateful.Session.Builder
{
    public class NHibernateStatefulSessionBuilder : ISessionBuilder<NHibernateStatefulSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatefulSessionBuilder(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        public NHibernateStatefulSession Construct(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            ISession openSession = sessionFactory.OpenSession();
            NHibernateStatefulSession statefulSession = new NHibernateStatefulSession(openSession);
            return statefulSession;
        }

        public void Destruct(NHibernateStatefulSession session)
        {
            ISession adapted = session.GetNativeSession<ISession>();
            adapted.Flush();
            adapted.Close();
            adapted.Dispose();
        }
    }
}
