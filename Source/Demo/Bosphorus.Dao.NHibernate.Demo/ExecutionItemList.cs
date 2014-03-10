using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Dal;
using Bosphorus.Dao.NHibernate.Demo.Model;

namespace Bosphorus.Dao.NHibernate.Demo
{
    public class ExecutionItemList : AbstractExecutionItemList
    {
        public ExecutionItemList(IDao dao, IDao<Temp> tempDao, IDao<Order> orderDao, ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao, IDao<Deneme> denemeDao, IDao<AdressType> addressTypeDao)
        {
            IDao<Customer> cachedCustomerDao = customerDao.Cached();
            Add("Temp Custom Query", () => from temp in tempDao.Query() where temp.Name == "Bilal" select  temp);
            Add(() => accountDao.GetAll());
            Add(() => orderDao.GetAll());
            Add("Desi > 10", () => from order in orderDao.Query() where order.Desi > 10 select  order);
            Add(() => accountDao.Save(new Account { Number = 1, Type = typeof(Account)}));
            Add(() => accountDao.GetById(Guid.NewGuid()));
            Add(() => denemeDao.GetAll());
            Add(() => customerDao.GetAll());
            Add("Cached", () => from model in cachedCustomerDao.Query() where model.Name == "Oğuz" select  model);
            Add(() => customerDao.GetBy(customerDao.SessionProvider.OpenSession(), "Onur"));
            Add(() => legancyDao.GetAll());
            Add("Custom", () => from model in legancyDao.Query() where model.APPLICATIONID == 1 select model);
            Add("AddressType", () => from model in addressTypeDao.Query() where model.Name == "Ev" select model);

            IEnumerable<Guid> guids = customerDao.GetAll().Select(model => model.Id).ToList();

            Add("AddressType", () =>
                from account in accountDao.Query()
                where guids.Contains(account.Customer_id)
                select new Account {Id= account.Id, Number = account.Number}
            );

            Add("Non Generic", () => from customer in dao.Query<Customer>() where customer.Name == "Onur" select customer);
        }
    }
}
