using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Join: AbstractExecutionItemList
    {
        public Join(IDao<Customer> customerDao, IDao<Account> accountDao)
        {
            this.Add("Join - Filtered Queryables", () => JoinFilteredQueryables(customerDao, accountDao));
        }

        private IEnumerable<Customer> JoinFilteredQueryables(IDao<Customer> customerDao, IDao<Account> accountDao)
        {
            IQueryable<Customer> customers = customerDao.Query().Where(customer => customer.Id == 1);
            IQueryable<Account> accounts = accountDao.Query().Where(account => account.Id == 1);

            var result =
                from customer in customers
                from account in accounts
                where customer.Id == account.Customer.Id
                select customer;

            return result;
        }
    }
}
