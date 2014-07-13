using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using NHibernate.Linq;
using Omu.ValueInjecter;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class AutoMap: AbstractExecutionItemList
    {
        public AutoMap(IDao<Account> accountDao)
            : base("AutoMap")
        {
            this.Add("View", () => from account in accountDao.Query() select AutoView<AccountView>.From(account));
            this.Add("View With Fetch", () => from account in accountDao.Query().Fetch(x => x.Customer) select AutoView<AccountView>.From(account));
            this.Add("View > Insert Model", () => InsertFromView(accountDao));
            this.Add("View With Fetch", () => from account in accountDao.Query().Fetch(x => x.Customer) select AutoView<AccountView>.From(account));
        }

        private Account InsertFromView(IDao<Account> accountDao)
        {
            AccountView accountView = new AccountView();
            accountView.Id = 3;
            accountView.No = 3;
            accountView.Name = "FromView";
            accountView.CustomerName = "Onur";
            accountView.CustomerCustomerTypeName = "Bireysel";

            Account account = AutoView<AccountView>.To<Account>(accountView);
            accountDao.Insert(account);
            return account;
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

            public static TModel To<TModel>(T viewModel) where TModel : class, new()
            {
                TModel result = new TModel();
                TModel foo = result.InjectFrom<UnflatLoopValueInjection>(viewModel) as TModel;
                return foo;
            }
        }
    }
}
