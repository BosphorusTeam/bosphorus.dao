using System;
using System.Collections.Generic;
using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.RelationByMap
{
    public class Cascade: AbstractExecutionItemList
    {
        public Cascade(IDao<Customer> customerDao, IDao<Account> accountDao)
            : base("RelationByMap - Cascade")
        {
            Add("Insert - SessionObject - Just Master", () => customerDao.Insert(CustomerBuilder.FromDatabase(1).Build()));

            Add("Insert - Customer", () => Insert(customerDao, accountDao));
            Add("Update - Customer", () => Update(customerDao));
            Add("Update - Account", () => Update(accountDao));
            Add("Delete - Customer", () => Delete(customerDao));
        }

        private Customer Delete(IDao<Customer> customerDao)
        {
            Account account = new Account();
            account.Id = 2;

            var customer = new Customer {Id = 2};
            customer.Accounts = new List<Account>();
            customer.Accounts.Add(account);
            account.Customer = customer;

            customerDao.Delete(customer);

            return customer;
        }

        private Account Update(IDao<Account> accountDao)
        {
            var customer = BuildCustomer();
            var account = BuildAccount(customer);

            accountDao.Update(account);
            return account;
        }

        private Customer Update(IDao<Customer> customerDao)
        {
            //NHibernateSession openSession = (NHibernateSession) bankDao.SessionManager.OpenSession();
            //ISession session = openSession.InnerSession;
            //var loadedCustomer = session.Get<Customer>(1);

            var customer = BuildCustomer();
            var account = BuildAccount(customer);

            customerDao.Update(customer);
            return customer;
        }

        private static Account BuildAccount(Customer customer)
        {
            int differentValue = DateTime.Now.Second / 10;

            Account account = new Account();
            account.Id = 5;
            account.Customer = customer;
            account.Name = "Maaş Hesabı " + differentValue;
            customer.Accounts.Add(account);

            return account;
        }

        private static Customer BuildCustomer()
        {
            int differentValue = DateTime.Now.Second / 30;

            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "Onur " + differentValue;
            customer.CustomerType = CustomerTypes.Bireysel;
            customer.Accounts = new List<Account>();
            return customer;
        }

        private Customer Insert(IDao<Customer> customerDao, IDao<Account> accountDao)
        {
            Customer customer = new Customer();
            customer.Name = "Onur";
            customer.CustomerType = CustomerTypes.Bireysel;
            customer.Accounts = new List<Account>();

            Account account = new Account();
            account.Customer = customer;
            account.Name = "Maaş Hesabı";
            customer.Accounts.Add(account);

            customerDao.Insert(customer);
            //accountDao.Insert(model);
            return customer;
        }
    }
}
