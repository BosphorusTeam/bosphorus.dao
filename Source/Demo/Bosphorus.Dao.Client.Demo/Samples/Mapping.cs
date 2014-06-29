using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Business.Model.Legacy;
using NHibernate.Linq;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class Mapping : AbstractExecutionItemList
    {
        public Mapping(ICustomerDao customerDao, IDao<Account> accountDao, IDao<IMPORTCARGOINFOSERVICE> legancyDao)
        {
            this.Add("Mapping - Override", () => legancyDao.GetAll());
            this.Add("Mapping - Relationed (Outer) (Detail > Master.Field)", () =>
                accountDao.Query()
                    .Select(account => account.Customer.Name));

            this.Add("Mapping - Relationed (Outer) (Detail > Master + Fetch)", () =>
                accountDao.Query()
                    .Fetch(x => x.Customer)
                    .Select(account => account));

            this.Add("Mapping - Relationed (Outer) (Master > Detail + Fetch)", () =>
                customerDao.Query()
                    .FetchMany(customer => customer.Accounts)
                    .Select(customer => customer));
        }
    }
}
