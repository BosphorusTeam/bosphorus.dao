using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Demo.Common;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList.Basic
{
    public class NonGeneric : AbstractMethodExecutionItemList
    {
        private readonly Bosphorus.Dao.Core.Dao.Facade.Dao dao;

        public NonGeneric(IResultTransformer resultTransformer, Core.Dao.Facade.Dao dao) 
            : base(resultTransformer)
        {
            this.dao = dao;
        }

        public IEnumerable<Bank> GetAll()
        {
            return dao.GetAll<Bank>();
        }

        public IQueryable<Bank> GetById()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            IQueryable<Bank> result = dao.GetById<Bank, int>(bank.Id);
            return result;
        }

        public Bank GetByIdSingle()
        {
            Bank bank = BankBuilder.FromDatabase().Build();
            Bank result = dao.GetByIdSingle<Bank, int>(bank.Id);
            return result;
        }

        public IEnumerable<Bank> GetByQuery()
        {
            IEnumerable<Bank> result = dao.GetByQuery<Bank>("select * from XBank");
            return result;
        }

        public IEnumerable<Bank> GetByNamedQuery()
        {
            var parameter = new { No = "0092" };
            IEnumerable<Bank> result = dao.GetByNamedQuery<Bank>("BankNamedQueryPositional", parameter);
            return result;
        }

        public IEnumerable<Bank> GetByNamedQueryFromProcedure()
        {
            var parameter = new { Parameter1 = "Deneme", Parameter2 = "Deneme2" };
            IEnumerable<Bank> result = dao.GetByNamedQuery<Bank>("BankNamedQueryFromProcedure", parameter);
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
