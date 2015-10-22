using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Castle.Windsor;
// ReSharper disable RedundantOverridenMember

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.RelationByMap
{
    public class Cascade_InSession : AbstractCascade
    {
        private readonly INHibernateStatefulDao<Customer> customerDao;
        private readonly INHibernateStatefulDao<Account> accountDao;

        public Cascade_InSession(IWindsorContainer container, INHibernateStatefulDao<Account> accountDao, INHibernateStatefulDao<Customer> customerDao) 
            : base(container, accountDao, customerDao)
        {
            this.accountDao = accountDao;
            this.customerDao = customerDao;
        }

        protected override Customer ReadCustomer()
        {
            Customer customer = CustomerBuilder.FromDatabaseWithChildren().Build();
            return customer;
        }

        protected override Account ReadAccount()
        {
            Account account = AccountBuilder.FromDatabase().Build();
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

        public override Customer Customer_Update_NewAccountList()
        {
            return base.Customer_Update_NewAccountList();
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
