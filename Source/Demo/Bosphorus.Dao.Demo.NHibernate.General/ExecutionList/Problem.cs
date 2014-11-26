using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList
{
    public class Problem: AbstractMethodExecutionItemList
    {
        public Problem(IResultTransformer resultTransformer, IDao<Customer> customerDao, IDao<Account> accountDao) 
            : base(resultTransformer)
        {
        }
    }
}
