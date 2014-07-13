using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using NHibernate.Linq;
using Omu.ValueInjecter;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class AutoMap: AbstractExecutionItemList
    {
        public AutoMap(IDao<Account> accountDao)
            : base("AutoMap")
        {
            this.Add("Default", () => from account in accountDao.Query() select AutoView<AccountView>.From(account));
            this.Add("Default With Fetch", () => from account in accountDao.Query().Fetch(x => x.Customer) select AutoView<AccountView>.From(account));
        }

        public class AccountView
        {
            public int Id { get; set; }
            public int No { get; set; }
            public string Name { get; set; }
            public string CustomerName { get; set; }
            public IList<Account> CustomerAccounts { get; set; }
            public string CustomerCustomerTypeName { get; set; }
        }

        internal class AutoView<T> where T : class, new()
        {
            public static T From<TMaster>(TMaster account)
            {
                T result = new T();
                T foo = result.InjectFrom<FlatLoopValueInjection>(account) as T;
                return foo;
            }
        }
    }
}
