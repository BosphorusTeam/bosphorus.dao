using System.Transactions;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.NHibernate.Demo.DTC
{
    class Program: IProgram
    {
        private readonly IDao<Customer> customerDao;
        private readonly IDao<LogModel> logModelDao;

        public Program(IDao<Customer> customerDao, IDao<LogModel> logModelDao)
        {
            this.customerDao = customerDao;
            this.logModelDao = logModelDao;
        }

        static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(args);
        }

        public void Run(string[] args)
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

            //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
            //{
            //    IEnumerable<Customer> enumerable = innerSession.Get<Customer>();

            //    innerSession.Flush();
            //    ts.Dispose();
            //    System.Transactions.Transaction.Current.Rollback();
            //    logModelDao.Save(logModel);
            //    ts.Complete();
            //}

        }
    }
}
