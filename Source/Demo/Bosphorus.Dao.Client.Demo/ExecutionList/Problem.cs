using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;

namespace Bosphorus.Dao.Client.Demo.ExecutionList
{
    public class Problem: AbstractMethodExecutionItemList
    {
        public Problem(IResultTransformer resultTransformer, IDao<Customer> customerDao, IDao<Account> accountDao) 
            : base(resultTransformer)
        {
        }
    }
}
