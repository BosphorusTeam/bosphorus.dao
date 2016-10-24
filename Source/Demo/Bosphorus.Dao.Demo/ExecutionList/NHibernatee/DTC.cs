using System.Transactions;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.ExecutionList.NHibernatee
{
    public class DTC: AbstractMethodExecutionItemList
    {
        private readonly IDao<Customer> customerDao;
        private readonly IDao<LogModel> logModelDao;

        public DTC(IWindsorContainer container, IDao<Customer> customerDao, IDao<LogModel> logModelDao) 
            : base(container)
        {
            this.customerDao = customerDao;
            this.logModelDao = logModelDao;
        }

        public void Try()
        {
            Customer customer = new Customer();
            customer.Name = "Onur";

            LogModel logModel = new LogModel();
            logModel.Message = "Oğuz";

            TransactionOptions transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.Serializable;

            //ISession openSession = bankDao.SessionManager.OpenSession();
            //global::NHibernate.ISession innerSession = ((NHibernateSession) openSession).InnerSession;
            //innerSession.FlushMode = FlushMode.;
            //innerSession.SaveOrUpdate(customer);
            //innerSession.Close();

            customerDao.Insert(customer);
            logModelDao.Insert(logModel);
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            {
                customerDao.Insert(customer);
                logModelDao.Insert(logModel);
                TransactionInformation transactionInformation = Transaction.Current.TransactionInformation;
                //ts.Complete();
            }

        }
    }
}
