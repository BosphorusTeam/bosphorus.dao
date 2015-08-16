using Bosphorus.Dao.Core.Session.Dao;
using Bosphorus.Dao.NHibernate.Stateful.Dao;

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
