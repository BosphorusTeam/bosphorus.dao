using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.NHibernate.Stateless.Dao;

namespace Bosphorus.Dao.NHibernate.Stateless.Session.Dao
{
    public class NHibernateStatelessSessionDaoRegisterer: ISessionDaoRegisterer
    {
        public void Register(SessionDaoRegistry sessionDaoRegistry)
        {
            sessionDaoRegistry.Register<NHibernateStatelessSession>(typeof(NHibernateStatelessDao<>));
        }
    }
}
