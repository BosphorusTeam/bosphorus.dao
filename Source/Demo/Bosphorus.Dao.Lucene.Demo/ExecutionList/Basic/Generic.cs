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
    }

}
