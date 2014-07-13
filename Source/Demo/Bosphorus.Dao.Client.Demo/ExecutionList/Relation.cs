using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.Utiliy.Relation;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class Relation: AbstractExecutionItemList
    {
        public Relation(IDao<Customer> customerDao, IDao<Account> accountDao)
            : base("Relation")
        {
            Add("SetId - Null", () => Reference<Customer>.WithId(instance => instance.Id, null));
            Add("SetId - 123", () => Reference<Customer>.WithId(instance => instance.Id, 123));
            Add("Insert - Customer", () => Insert(customerDao, accountDao));
            Add("Update - Customer", () => Update(customerDao));
            Add("Update - Account", () => Update(accountDao));
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
            account.No = differentValue;
            account.Name = "Maaş Hesabı 2";
            account.Type = typeof (Account);
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
            account.No = 1;
            account.Name = "Maaş Hesabı";
            account.Type = typeof (Account);
            customer.Accounts.Add(account);

            customerDao.Insert(customer);
            //accountDao.Insert(account);
            return customer;
        }
    }
}
