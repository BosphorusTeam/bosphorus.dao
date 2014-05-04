using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Dal;
using Bosphorus.Dao.NHibernate.Demo.Model;

namespace Bosphorus.Dao.Client.Demo
{
    public class ExecutionItemList : AbstractExecutionItemList
    {
        public ExecutionItemList(IDao dao, IDao<Temp> tempDao, IDao<Order> orderDao, ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao, IDao<Deneme> denemeDao, IDao<AdressType> addressTypeDao, IDao<NotRegisteredModel> notRegisteredModelDao)
        {
            IDao<Customer> cachedCustomerDao = customerDao.Cached();

            this.Add(() => notRegisteredModelDao.GetAll());
            this.Add(() => accountDao.GetAll());
            this.Add(() => orderDao.GetAll());
            this.Add(() => accountDao.GetById(Guid.NewGuid()));
            this.Add(() => denemeDao.GetAll());
            this.Add(() => customerDao.GetAll());
            this.Add(() => customerDao.GetBy(customerDao.SessionProvider.OpenSession(), "Onur"));
            this.Add(() => legancyDao.GetAll());
            this.Add(() => from order in orderDao.Query() where order.Desi > 10 select order);

            this.Add(() => accountDao.Save(new Account { Number = 1, Type = typeof(Account)}));

            this.Add("Desi > 10", () => from order in orderDao.Query() where order.Desi > 10 select order);
            this.Add("Temp Custom Query", () => from temp in tempDao.Query() where temp.Name == "Bilal" select temp);
            this.Add("Cached", () => from model in cachedCustomerDao.Query() where model.Name == "Oğuz" select model);
            this.Add("Custom", () => from model in legancyDao.Query() where model.APPLICATIONID == 1 select model);
            this.Add("AddressType", () => from model in addressTypeDao.Query() where model.Name == "Ev" select model);
            this.Add("Non Generic", () => from customer in dao.Query<Customer>() where customer.Name == "Onur" select customer);

            IEnumerable<Guid> guids = customerDao.GetAll().Select(model => model.Id).ToList();
            this.Add("AddressType", () =>
                from account in accountDao.Query()
                where guids.Contains(account.Customer_id)
                select new Account {Id= account.Id, Number = account.Number}
            );

        }
    }
}
