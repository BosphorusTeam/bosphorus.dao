using System.Collections.Generic;
using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.ExecutionList.NHibernatee.Extension.Temp;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.ExecutionList.NHibernatee.Extension
{
    public class Hybrid : AbstractMethodExecutionItemList
    {
        private readonly IDao<Customer> customerDao;
        private readonly IDao<Account> accountDao;
        private readonly IEnumerable<int> selectedAccountGuids;
        private readonly IQueryable<Account> cachedAccounts;

        public Hybrid(IWindsorContainer container, IDao<Customer> customerDao, IDao<Account> accountDao, ISessionProvider sessionProvider)
            : base(container)
        {
            this.customerDao = customerDao;
            this.accountDao = accountDao;
            ISession applicationSession = sessionProvider.Current(sessionScope: SessionScope.Application);
            cachedAccounts = accountDao.Query(applicationSession).ToList().AsQueryable();
            selectedAccountGuids = cachedAccounts.Select(x => x.Customer.Id);
        }

        public IQueryable<Account> Contains()
        {
            IQueryable<Account> result =
                from account in accountDao.Query()
                where selectedAccountGuids.Contains(account.Customer.Id)
                select new Account { Id = account.Id };

            return result;
        }

        public IQueryable Join()
        {
            var result =
                from customer in customerDao.Query()
                join account in cachedAccounts on customer.Id equals account.Customer.Id
                select new {customer, temp = 1};

            return result.Optimize();
        }
    }
}
