using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList.Basic
{
    public class Generic : AbstractMethodExecutionItemList
    {
        private readonly INHibernateStatefulDao<Bank> dao;

        public Generic(IWindsorContainer container, INHibernateStatefulDao<Bank> dao)
            : base(container)
        {
            this.dao = dao;
        }

        public IEnumerable<Bank> GetAll()
        {
            return dao.GetAll();
        }

        public IQueryable<Bank> GetById()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            IQueryable<Bank> result = dao.GetById(bank.Id);
            return result;
        }

        public Bank GetByIdSingle()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            Bank result = dao.GetByIdSingle(bank.Id);
            return result;
        }

        public IEnumerable<Bank> GetByQuery()
        {
            IEnumerable<Bank> result = dao.GetByQuery("select * from XBank");
            return result;
        }

        public IEnumerable<Bank> GetByNamedQuery()
        {
            var parameter = new {No = "0092"};
            IEnumerable<Bank> result = dao.GetByNamedQuery("BankNamedQueryPositional", parameter);
            return result;
        }

        public IEnumerable<Bank> GetByNamedQueryFromProcedure()
        {
            var parameter = new {Parameter1 = "Deneme", Parameter2 = "Deneme2"};
            dao.GetByQuery("call XBANKPROC ( :Parameter1, :Parameter2 )", parameter);

            //var parameter = new {Parameter1 = "Deneme", Parameter2 = "Deneme2"};
            IEnumerable<Bank> result = dao.GetByNamedQuery("BankNamedQueryFromProcedure", parameter);
            return result;
        }

        public Bank Insert()
        {
            Bank bank = BankBuilder.Default.Build();
            Bank result = dao.Insert(bank);
            return result;
        }

        public Bank Update()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            bank.No = Randomize.String();
            Bank result = dao.Update(bank);
            return result;
        }

        public Bank Delete()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            dao.Delete(bank);
            return bank;
        }
    }
}
