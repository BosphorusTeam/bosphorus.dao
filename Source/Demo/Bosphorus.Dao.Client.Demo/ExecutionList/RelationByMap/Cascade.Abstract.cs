using System;
using System.Collections.Generic;
using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.RelationByMap
{
    public abstract class AbstractCascade : AbstractMethodExecutionItemList
    {
        private readonly IDao<Customer> customerDao;
        private readonly IDao<Account> accountDao;

        public AbstractCascade(IResultTransformer resultTransformer, IDao<Account> accountDao, IDao<Customer> customerDao) 
            : base(resultTransformer)
        {
            this.accountDao = accountDao;
            this.customerDao = customerDao;
        }

        protected abstract Customer ReadCustomer();

        protected abstract Account ReadAccount();

        public virtual Customer Customer_Insert()
        {
            Customer customer = CustomerBuilder.Default.Build();
            Account account1 = AccountBuilder.Default.Build();
            Account account2 = AccountBuilder.Default.Build();

            account1.Customer = customer;
            account2.Customer = customer;

            customer.PrimaryAccount = account1;
            //customer.Accounts.Add(account1);
            //customer.Accounts.Add(account2);

            customerDao.Insert(customer);
            return customer;
        }

        public virtual Customer Customer_Update()
        {
            var customer = ReadCustomer();
            customer.Name = Randomize.String();
            customerDao.Update(customer);
            return customer;
        }

        //FIXME: Debug ederken bir tane account ekliyor ama run ederken 2 tane????
        public virtual Customer Customer_Update_AddAccount()
        {
            var customer = ReadCustomer();
            var newAccount = AccountBuilder.Default.Build();
            customer.Accounts.Add(newAccount);
            newAccount.Customer = customer;

            customerDao.Update(customer);
            return customer;
        }

        public virtual Customer Customer_Update_RemoveAccount()
        {
            Customer customer = ReadCustomer();
            Account account = customer.Accounts[0];

            customer.Accounts.Remove(account);

            customerDao.Update(customer);
            return customer;
        }

        public virtual Customer Customer_Delete()
        {
            Customer customer = ReadCustomer();
            customerDao.Delete(customer);
            return customer;
        }

        public virtual Account Account_Insert()
        {
            //Customer customer = ReadCustomer();
            Account account = AccountBuilder.Default.Build();

            account.Customer = new Customer() {Id = 1};

            accountDao.Insert(account);
            return account;
        }

        public virtual Account Account_Update()
        {
            Account account = ReadAccount();
            account.Name = Randomize.String();
            accountDao.Update(account);
            return account;
        }

        public virtual Account Account_Delete()
        {
            Account account = ReadAccount();
            accountDao.Delete(account);
            return account;
        }

    }
}
