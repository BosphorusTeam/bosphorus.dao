using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Business.Model.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;
using NHibernate.Linq;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Simple : AbstractExecutionItemList
    {
        public Simple(IDao nonGenericDao, IDao<CargoOrder> orderDao, ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao, IDao<LogModel> logDao)
        {
            this.Add(() => customerDao.GetAll());
            this.Add(() => accountDao.GetById(Guid.NewGuid()));
            this.Add(() => accountDao.Insert(new Account { No = 1, Name = "Onur Eker", Type = typeof(Account) }));
            this.Add(() => from order in orderDao.Query() where order.Desi > 10 select order);
            this.Add("Dao - Non Generic", () => from customer in nonGenericDao.Query<Customer>() where customer.Name == "Onur" select customer);
            
            this.Add(() => legancyDao.GetCustomQuery1());

        }
    }
}
