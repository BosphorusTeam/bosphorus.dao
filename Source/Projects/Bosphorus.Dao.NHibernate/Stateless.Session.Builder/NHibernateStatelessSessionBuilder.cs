using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Builder;
using Bosphorus.Dao.NHibernate.Common.Session.Factory;
using NHibernate;

namespace Bosphorus.Dao.NHibernate.Stateless.Session.Builder
{
    public class NHibernateStatelessSessionBuilder: ISessionBuilder<NHibernateStatelessSession>
    {
        private readonly INHibernateSessionFactoryBuilder sessionFactoryBuilder;

        public NHibernateStatelessSessionBuilder(INHibernateSessionFactoryBuilder sessionFactoryBuilder)
        {
            this.sessionFactoryBuilder = sessionFactoryBuilder;
        }

        public NHibernateStatelessSession Construct(string aliasName)
        {
            ISessionFactory sessionFactory = sessionFactoryBuilder.Build(aliasName);
            IStatelessSession nativeSession = sessionFactory.OpenStatelessSession();
            NHibernateStatelessSession result = new NHibernateStatelessSession(nativeSession);
            return result;
        }

        public void Destruct(NHibernateStatelessSession session)
        {
            IStatelessSession adapted = session.GetNativeSession<IStatelessSession>();
            adapted.Close();
        }
    }
}
