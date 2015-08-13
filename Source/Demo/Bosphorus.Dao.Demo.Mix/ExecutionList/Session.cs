using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.Client.Model;
using Bosphorus.Dao.Client.ResultTransformer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Demo.Mix.ExecutionList
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<LogModel> logDao;
        private readonly IDao<Customer> customerDao;

        public Session(IResultTransformer resultTransformer, IDao<Bank> bankDao, IDao<LogModel> logDao, IDao<Customer> customerDao, ISessionProvider sessionProvider) 
            : base(resultTransformer)
        {
            this.bankDao = bankDao;
            this.logDao = logDao;
            this.customerDao = customerDao;
        }

        public IEnumerable<Bank> Lucene()
        {
            IEnumerable<Bank> result = bankDao.Query().Take(1);
            return result;
        }

        public IEnumerable<LogModel> Stateless()
        {
            IEnumerable<LogModel> result = logDao.GetAll();
            return result;
        }

        public IEnumerable<Customer> Stateful()
        {
            IEnumerable<Customer> result = customerDao.GetAll();
            return result;
        }
    }
}
