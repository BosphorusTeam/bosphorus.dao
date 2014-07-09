using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.LinQ.CastAs;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Coalesce;
using Bosphorus.Dao.NHibernate.Extension.LinQ.In;

namespace Bosphorus.Dao.Client.Demo.Samples
{
    public class LinqProvider : AbstractExecutionItemList
    {
        public LinqProvider(IDao<Customer> customerDao, IDao<Account> accountDao)
        {
            IDao<Account> cachedAccountDao = accountDao.Cached();
            string[] inList = {"Onur", "Oğuz"};

            this.Add("LinqProvider - Cached", () => from model in cachedAccountDao.Query() where model.Name == "Onur" select model);

            this.Add("LinqProvider - LinQ In (Values)", () => from model in accountDao.Query() where model.Name.In("Onur", "Oğuz") select model);
            this.Add("LinqProvider - LinQ Not In (Values)", () => from model in accountDao.Query() where model.Name.NotIn("Onur", "Oğuz") select model);
            this.Add("LinqProvider - LinQ In (List)", () => from model in accountDao.Query() where model.Name.In(inList) select model);
            this.Add("LinqProvider - LinQ Not In (List)", () => from model in accountDao.Query() where model.Name.NotIn(inList) select model);

            this.Add("LinqProvider - LinQ Coalesce", () => from model in accountDao.Query() where model.Name.Coalesce("Deneme") == "Deneme" select model);
            this.Add("LinqProvider - LinQ Cast", () => from model in accountDao.Query() where model.Name.CastAs<string>() == "Deneme" select model);

            //this.Add("LinqProvider - LinQ Equals ", () => from model in accountDao.Query() where model.No  == 0L select model);
            //this.Add("LinqProvider - LinQ Soundex", () => from model in accountDao.Query() select model.Name.Soundex());
            //this.Add("LinqProvider - LinQ Oracle Left Join", () =>
            //    from account in accountDao.Query()
            //    from customer in customerDao.Query()
            //    where account.Customer.Id == customer.Id.OraclePlus()
            //    select account);

        }
    }
}
