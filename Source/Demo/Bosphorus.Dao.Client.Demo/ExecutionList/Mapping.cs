using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Business.Model.Legacy;
using NHibernate.Linq;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class Mapping : AbstractExecutionItemList
  {
        public Mapping(ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao)
            : base("Mapping")
        {
            this.Add("Override", () => legancyDao.GetAll());
            this.Add("Relationed (Outer) (Detail > Master.Field)", () =>
                accountDao.Query()
                    .Select(account => account.Customer.Name));

            this.Add("Relationed (Outer) (Detail > Master + Fetch)", () =>
                accountDao.Query()
                    .Fetch(x => x.Customer)
                    .Select(account => account));

            this.Add("Relationed (Outer) (Master > Detail + Fetch)", () =>
                customerDao.Query()
                    .FetchMany(customer => customer.Accounts)
                    .Select(customer => customer));
        }
    }
}
