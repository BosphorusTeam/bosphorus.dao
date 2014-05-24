using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;

namespace Bosphorus.Dao.NHibernate.Demo.Client
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
            WindowsRunner.Run<Program>(args);
        }

        public void Run(string[] args)
        {
            Customer customer = new Customer();
            customer.Name = "Onur";

            LogModel logModel = new LogModel();
            logModel.Message = "Oğuz";

            using (TransactionScope ts = new TransactionScope())
            {
                customerDao.Save(customer);
                logModelDao.Save(logModel);
            }

        }
    }
}
