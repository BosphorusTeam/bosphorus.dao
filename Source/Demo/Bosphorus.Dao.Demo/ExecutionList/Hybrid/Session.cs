using System.Collections.Generic;
using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.ExecutionList.Hybrid
{
    public class Session : AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> bankDao;
        private readonly IDao<LogModel> logDao;
        private readonly IDao<Customer> customerDao;

        public Session(IWindsorContainer container, IDao<Bank> bankDao, IDao<LogModel> logDao, IDao<Customer> customerDao) 
            : base(container)
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
