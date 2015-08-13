using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.NHibernate.Stateful.Session.Dao
{
    public class NHibernateStatefulSessionDaoRegisterer: ISessionDaoRegisterer
    {
        public void Register(SessionDaoRegistry sessionDaoRegistry)
        {
            sessionDaoRegistry.Register<NHibernateStatefulSession>(typeof(NHibernateStatefulDao<>));
        }
    }
}
