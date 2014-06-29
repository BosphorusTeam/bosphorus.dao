using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Session : AbstractExecutionItemList
    {
        public Session(ICustomerDao customerDao, IDao<Account> accountDao, IDao<LogModel> logDao)
        {
            this.Add("Session - Default", () => accountDao.GetAll());
            this.Add("Session - Log", () => logDao.GetAll());
            this.Add("Session - From Parameter", () => customerDao.GetBy(customerDao.SessionProvider.OpenSession(), "Onur"));
        }
    }
}
