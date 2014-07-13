using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class Session : AbstractExecutionItemList
    {
        public Session(ICustomerDao customerDao, IDao<Account> accountDao, IDao<LogModel> logDao)
            : base("Session")
        {
            this.Add("Default", () => accountDao.GetAll());
            this.Add("Log", () => logDao.GetAll());
            this.Add("From Parameter", () => customerDao.GetBy(customerDao.SessionProvider.OpenSession(), "Onur"));
        }
    }
}
