using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Extension.LinQ.CastAs;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Coalesce;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Decode;
using Bosphorus.Dao.NHibernate.Extension.LinQ.In;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Extension
{
    public class LinqProvider : AbstractExecutionItemList
    {
        public LinqProvider(IDao<Customer> customerDao, IDao<Account> accountDao)
            : base("LinqProvider")
        {
            string[] inList = {"Onur", "Oğuz"};

            this.Add("Cached", () => from model in accountDao.Cached().Query() where model.Name == "Onur" select model);
            this.Add("LinQ In (Values)", () => from model in accountDao.Query() where model.Name.In("Onur", "Oğuz") select model);
            this.Add("LinQ Not In (Values)", () => from model in accountDao.Query() where model.Name.NotIn("Onur", "Oğuz") select model);
            this.Add("LinQ In (List)", () => from model in accountDao.Query() where model.Name.In(inList) select model);
            this.Add("LinQ Not In (List)", () => from model in accountDao.Query() where model.Name.NotIn(inList) select model);

            this.Add("LinQ Coalesce", () => from model in accountDao.Query() where model.Name.Coalesce("Deneme") == "Deneme" select model);
            this.Add("LinQ Cast", () => from model in accountDao.Query() where model.Name.CastAs<string>() == "Deneme" select model);

            this.Add("LinQ Decode 1", () => from model in customerDao.Query() select model.Name.Decode("Onur", 1));
            this.Add("LinQ Decode 1 - Fallback", () => from model in customerDao.Query() select model.Name.Decode("Onur", 1, -1));
            this.Add("LinQ Decode 2", () => from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2));
            this.Add("LinQ Decode 2 - Fallback", () => from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2, -1));
            this.Add("LinQ Decode 3", () => from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2, "Gökhan", 3));
            this.Add("LinQ Decode 3 - Fallback", () => from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2, "Gökhan", 3, - 1));

            //this.Add("LinqProvider - LinQ Equals ", () => from model in accountDao.Query() where model.No  == 0L select model);
            //this.Add("LinqProvider - LinQ Soundex", () => from model in accountDao.Query() select model.Name.Soundex());
            //this.Add("LinqProvider - LinQ Oracle Left Join", () =>
            //    from model in accountDao.Query()
            //    from customer in bankDao.Query()
            //    where model.Customer.Id == customer.Id.OraclePlus()
            //    select model);

        }
    }
}
