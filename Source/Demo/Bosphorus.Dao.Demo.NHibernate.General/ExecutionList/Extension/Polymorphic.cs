using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Demo.Runner.Executable;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Extension
{
    public class Polymorphic : AbstractMethodExecutionItemList
    {
        private readonly IDao<Account> accountDao;
        private readonly IEnumerable<int> selectedAccountGuids;
        private readonly IQueryable<Account> selectedAccounts;

        public Polymorphic(IWindsorContainer container, IDao<Account> accountDao)
            : base(container)
        {
            this.accountDao = accountDao;
            selectedAccounts = accountDao.Query();
            selectedAccountGuids = selectedAccounts.Select(x => x.Customer.Id);
        }

        public IQueryable<Account> Contains()
        {
            IQueryable<Account> result =
                from account in accountDao.Query()
                where selectedAccountGuids.Contains(account.Customer.Id)
                select new Account { Id = account.Id };

            return result;
        }

        public IQueryable<Account> Join()
        {
            IQueryable<Account> result =
                from account in accountDao.Query()
                from selectedAccount in selectedAccounts
                where selectedAccount.Customer.Id == account.Customer.Id
                select new Account {Id = account.Id};

            return result;
        }
    }
}
