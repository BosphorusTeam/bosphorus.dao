using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Lucene.Demo.ExecutionList.Basic
{
    public class Generic : MethodExecutionItemList
    {
        private readonly IDao<Bank> dao;

        public Generic(IResultTransformer resultTransformer, IDao<Bank> dao) 
            : base(resultTransformer)
        {
            this.dao = dao;
        }

        public Bank Insert()
        {
            Bank bank = new Bank();
            bank.No = "1";
            bank.Name = "Citibank";

            Bank result = dao.Insert(bank);
            return result;
        }
        public IEnumerable<Bank> Insert_10_000()
        {
            int count = 10000;
            IList<Bank> bankList = new List<Bank>(count);
            for (int i = 0; i < count; i++)
            {
                Bank bank = new Bank();
                bank.No = i.ToString();
                bank.Name = "Citibank " + i;

                bankList.Add(bank);
            }

            IEnumerable<Bank> result = dao.Insert(bankList);
            return result;
        }
    }

}
