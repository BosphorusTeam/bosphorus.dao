using System.Linq;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Extension.LinQ.CastAs;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Coalesce;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Decode;
using Bosphorus.Dao.NHibernate.Extension.LinQ.In;
using Bosphorus.Dao.NHibernate.Extension.LinQ.Soundex;
using Bosphorus.Demo.Runner.Executable;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Extension
{
    public class LinqProvider : AbstractMethodExecutionItemList
    {
        private readonly IDao<Customer> customerDao;
        private readonly IDao<Account> accountDao;
        private readonly string[] inList;

        //this.Add("LinqProvider - LinQ Equals ", () => from model in accountDao.Query() where model.No  == 0L select model);
        //this.Add("LinqProvider - LinQ Oracle Left Join", () =>
        //    from model in accountDao.Query()
        //    from customer in bankDao.Query()
        //    where model.Customer.Id == customer.Id.OraclePlus()
        //    select model);

        public LinqProvider(IWindsorContainer container, IDao<Customer> customerDao, IDao<Account> accountDao) 
            : base(container)
        {
            this.customerDao = customerDao;
            this.accountDao = accountDao;
            inList = new[] {"Onur", "Oğuz"};
        }

        public IQueryable<Account> Cached()
        {
            IQueryable<Account> result = from model in accountDao.Cached().Query() where model.Name == "Onur" select model;
            return result;
        }

        public IQueryable<Account> Soundex()
        {
            IQueryable<Account> result = from model in accountDao.Query() where model.Name.Soundex() == "?" select model;
            return result;
        }

        public IQueryable<Account> In_Values()
        {
            IQueryable<Account> result = from model in accountDao.Query() where model.Name.In("Onur", "Oğuz") select model;
            return result;
        }

        public IQueryable<Account> In_List()
        {

            IQueryable<Account> result = from model in accountDao.Query() where model.Name.In(inList) select model;
            return result;
        }

        public IQueryable<Account> NotIn_Values()
        {
            IQueryable<Account> result = from model in accountDao.Query() where model.Name.NotIn("Onur", "Oğuz") select model;
            return result;
        }

        public IQueryable<Account> NotIn_List()
        {
            IQueryable<Account> result = from model in accountDao.Query() where model.Name.NotIn(inList) select model;
            return result;
        }

        public IQueryable<Account> Coalesce()
        {
            IQueryable<Account> result = from model in accountDao.Query() where model.Name.Coalesce("Deneme") == "Deneme" select model;
            return result;
        }

        public IQueryable<Account> Cast()
        {
            IQueryable<Account> result = from model in accountDao.Query() where model.Name.CastAs<string>() == "Deneme" select model;
            return result;
        }

        public IQueryable<int> Decode_1()
        {
            IQueryable<int> result = from model in customerDao.Query() select model.Name.Decode("Onur", 1);
            return result;
        }

        public IQueryable<int> Decode_1Fallback()
        {
            IQueryable<int> result = from model in customerDao.Query() select model.Name.Decode("Onur", 1, -1);
            return result;
        }

        public IQueryable<int> Decode_2()
        {
            IQueryable<int> result = from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2);
            return result;
        }

        public IQueryable<int> Decode_2Fallback()
        {
            IQueryable<int> result = from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2, -1);
            return result;
        }

        public IQueryable<int> Decode_3()
        {
            IQueryable<int> result = from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2, "Devrim", 3);
            return result;
        }

        public IQueryable<int> Decode_3Fallback()
        {
            IQueryable<int> result = from model in customerDao.Query() select model.Name.Decode("Onur", 1, "Oğuz", 2, "Devrim", 3, -1);
            return result;
        }
    }
}
