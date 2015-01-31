using System.Collections.Generic;
using System.Transactions;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.Common.Log;

namespace Bosphorus.Dao.Demo.NHibernate.DTC
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
            ConsoleRunner.Run<Program>(Environment.Development, Perspective.Debug, args);
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
