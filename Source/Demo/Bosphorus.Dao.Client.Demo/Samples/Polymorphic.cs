using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Polymorphic : AbstractExecutionItemList
    {
        public Polymorphic(IDao<Account> accountDao)
            : base("Polymorphic")
        {
            IEnumerable<Account> selectedAccounts = accountDao.Query();
            IEnumerable<int> selectedAccountGuids = selectedAccounts.Select(x => x.Customer.Id);

            this.Add("Contains", () =>
                from account in accountDao.Query()
                where selectedAccountGuids.Contains(account.Customer.Id)
                select new Account { Id = account.Id, No = account.No }
            );

            this.Add("Join", () =>
                from account in accountDao.Query()
                from selectedAccount in selectedAccounts
                where selectedAccount.Customer.Id == account.Customer.Id
                select new Account { Id = account.Id, No = account.No }
            );
        }
    }
}
