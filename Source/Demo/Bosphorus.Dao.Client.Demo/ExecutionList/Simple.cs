using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Business.Model.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class Simple : AbstractExecutionItemList
    {
        public Simple(IDao nonGenericDao, IDao<CargoOrder> orderDao, ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao, IDao<LogModel> logDao)
            : base("Simple")
        {
            this.Add(() => customerDao.GetAll());
            this.Add(() => accountDao.GetById(1));
            this.Add(() => accountDao.Insert(new Account { No = 1, Name = "Maaş Hesabı", Type = typeof(Account) }));
            this.Add(() => customerDao.Insert(new Customer { Name = "Onur Eker", Accounts  = new[]{new Account {Id=1}}}));
            this.Add(() => from order in orderDao.Query() where order.Desi > 10 select order);
            this.Add("Dao - Non Generic", () => from customer in nonGenericDao.Query<Customer>() where customer.Name == "Onur" select customer);
            
            this.Add(() => legancyDao.GetCustomQuery1());

        }
    }
}
