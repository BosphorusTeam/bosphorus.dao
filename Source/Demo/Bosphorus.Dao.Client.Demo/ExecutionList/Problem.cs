using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class Problem: AbstractExecutionItemList
    {
        public Problem(IDao<Customer> customerDao, IDao<Account> accountDao)
            : base("Problem")
        {
            //this.Add("Senaryo 1", () => JoinFilteredQueryables(customerDao, accountDao));
            //this.Add("Senaryo 2", () => JoinFilteredQueryables2(customerDao, accountDao));
        }

        //private Customer JoinFilteredQueryables(IDao<Customer> customerDao, IDao<Account> accountDao)
        //{
        //    Customer customer = customerDao.Query().First();
        //    customer.Name = DateTime.Now.ToString();

        //    ISession session = accountDao.SessionManager.OpenSession();
        //    customerDao.Update(session, customer);

        //    return customer;
        //}

        //private Customer JoinFilteredQueryables2(IDao<Customer> customerDao, IDao<Account> accountDao)
        //{
        //    ISession session = customerDao.SessionManager.OpenSession();
        //    Customer customer = customerDao.Query(session).First();
        //    customer.Name = DateTime.Now.ToString();

        //    customerDao.Update(session, customer);

        //    return customer;
        //}
    }
}
