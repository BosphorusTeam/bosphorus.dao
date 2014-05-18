using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Dal.Default;
using Bosphorus.Dao.NHibernate.Demo.Model.Default;
using Bosphorus.Dao.NHibernate.Demo.Model.Default.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Model.Log;

namespace Bosphorus.Dao.Client.Demo
{
    public class ExecutionItemList : AbstractExecutionItemList
    {
        public ExecutionItemList(IDao nonGenericDao, IDao<Order> orderDao, ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao, IDao<LogModel> logDao)
        {
            IDao<Customer> cachedCustomerDao = customerDao.Cached();


            this.Add(() => accountDao.GetAll());
            this.Add(() => logDao.GetAll());
            this.Add(() => accountDao.GetById(Guid.NewGuid()));
            this.Add(() => customerDao.GetAll());
            this.Add(() => customerDao.GetBy(customerDao.SessionProvider.OpenSession(), "Onur"));
            this.Add(() => legancyDao.GetAll());
            this.Add(() => from order in orderDao.Query() where order.Desi > 10 select order);
            this.Add(() => accountDao.Save(new Account { Number = 1, Name = "Onur Eker", Type = typeof(Account)}));

            this.Add("Cached", () => from model in cachedCustomerDao.Query() where model.Name == "Oğuz" select model);
            this.Add("Custom", () => from model in legancyDao.Query() where model.APPLICATIONID == 1 select model);
            this.Add("Non Generic", () => from customer in nonGenericDao.Query<Customer>() where customer.Name == "Onur" select customer);

            IEnumerable<Account> selectedAccounts = accountDao.Query().Take(2);
            IQueryable<Guid> selectedAccountGuids = selectedAccounts.Select(x => x.Customer_id).AsQueryable();

            this.Add("Polymorphic In", () =>
                from account in accountDao.Query()
                where selectedAccountGuids.Contains(account.Customer_id)
                select new Account { Id = account.Id, Number = account.Number }
            );

            this.Add("Polymorphic Join", () =>
                from account in accountDao.Query()
                from selectedAccount in selectedAccounts
                where selectedAccount.Customer_id == account.Customer_id
                select new Account { Id = account.Id, Number = account.Number }
            );

        }
    }
}
