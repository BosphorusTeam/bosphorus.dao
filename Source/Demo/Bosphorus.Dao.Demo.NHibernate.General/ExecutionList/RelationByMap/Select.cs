using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Demo.Runner.Executable;
using Castle.Windsor;
using NHibernate.Linq;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.RelationByMap
{
    public class Select: AbstractMethodExecutionItemList
    {
        private readonly INHibernateStatefulDao<Customer> customerDao;
        private readonly INHibernateStatefulDao<Account> accountDao;

        public Select(IWindsorContainer container, INHibernateStatefulDao<Customer> customerDao, INHibernateStatefulDao<Account> accountDao)
            : base(container)
        {
            this.customerDao = customerDao;
            this.accountDao = accountDao;
        }

        public IEnumerable<string> Select_MasterField_From_Detail()
        {
            IQueryable<string> result = accountDao.Query().Select(account => account.Customer.Name);
            return result;
        }

        public IQueryable<Account> Select_Detail_From_Detail_With_Fetch_Master_()
        {
            IQueryable<Account> result = accountDao.Query().Fetch(x => x.Customer).Select(account => account);
            return result;
        }

        public IQueryable<Customer> Select_Master_From_Master_With_Fetch_Detail()
        {
            IQueryable<Customer> result = customerDao.Query().FetchMany(customer => customer.Accounts).Select(customer => customer);
            return result;
        }

        public IEnumerable<Customer> JoinFilteredQueryables()
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
