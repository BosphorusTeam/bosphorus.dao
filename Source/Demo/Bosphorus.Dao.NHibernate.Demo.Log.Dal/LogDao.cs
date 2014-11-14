using Bosphorus.Dao.Core.Session.Manager.Factory;
using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;
using Bosphorus.Dao.NHibernate.Session.Manager.Factory;

namespace Bosphorus.Dao.NHibernate.Demo.Log.Dal
{
    public class LogDao: NHibernateDao<LogModel>
    {
        public LogDao(ISessionManagerFactory sessionManagerFactory) 
            : base(sessionManagerFactory, "LOG")
        {
        }
    }
}
