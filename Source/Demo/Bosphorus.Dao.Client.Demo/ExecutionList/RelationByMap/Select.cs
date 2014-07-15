using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using NHibernate.Linq;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.RelationByMap
{
    public class Select: AbstractExecutionItemList
    {
        public Select(IDao<Customer> customerDao, IDao<Account> accountDao)
            : base("RelationByMap - Select")
        {
            this.Add("select Master.Field from Detail", () =>
                accountDao.Query()
                    .Select(account => account.Customer.Name));

            this.Add("select Detail from Detail (With Fetch Master)", () =>
                accountDao.Query()
                    .Fetch(x => x.Customer)
                    .Select(account => account));

            this.Add("select Master from Master (With Fetch Detail)", () =>
                customerDao.Query()
                    .FetchMany(customer => customer.Accounts)
                    .Select(customer => customer));

            this.Add("Filtered Queryables", () => JoinFilteredQueryables(customerDao, accountDao));
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
