using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Bosphorus.Dao.NHibernate.Dao;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.RelationByMap
{
    public class Cascade_OutSession : AbstractCascade
    {
        private readonly INHibernateStatefulDao<Customer> customerDao;
        private readonly INHibernateStatefulDao<Account> accountDao;

        public Cascade_OutSession(IResultTransformer resultTransformer, INHibernateStatefulDao<Account> accountDao, INHibernateStatefulDao<Customer> customerDao) 
            : base(resultTransformer, accountDao, customerDao)
        {
            this.accountDao = accountDao;
            this.customerDao = customerDao;
        }
        
        protected override Customer ReadCustomer()
        {
            Customer customer = CustomerBuilder.FromDatabase().Evict().Build();
            return customer;
        }

        protected override Account ReadAccount()
        {
            Account account = AccountBuilder.FromDatabase().Evict().Build();
            return account;
        }

        public override Customer Customer_Insert()
        {
            return base.Customer_Insert();
        }

        public override Customer Customer_Update()
        {
            return base.Customer_Update();
        }

        public override Customer Customer_Update_AddAccount()
        {
            return base.Customer_Update_AddAccount();
        }

        public override Customer Customer_Update_RemoveAccount()
        {
            return base.Customer_Update_RemoveAccount();
        }

        public override Customer Customer_Delete()
        {
            return base.Customer_Delete();
        }

        public override Account Account_Insert()
        {
            return base.Account_Insert();
        }

        public override Account Account_Update()
        {
            return base.Account_Update();
        }

        public override Account Account_Delete()
        {
            return base.Account_Delete();
        }
    }
}
