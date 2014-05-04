using Bosphorus.Dao.NHibernate.Dao;
using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Demo.Model.Log;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;

namespace Bosphorus.Dao.NHibernate.Demo.Dal.Log
{
    public class LogDao: NHibernateDao<LogModel>
    {
        public LogDao(ISessionProviderFactory sessionProviderFactory) 
            : base(sessionProviderFactory, "LOG")
        {
        }
    }
}
