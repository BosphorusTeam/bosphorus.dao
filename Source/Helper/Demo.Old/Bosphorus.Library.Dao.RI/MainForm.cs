using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bosphorus.Library.Dao.RI.Dao;
using Bosphorus.Library.Dao.RI.Entities;
using System.Threading;
using Bosphorus.Library.Dao.Core.Extension.Model.Repository;
using Bosphorus.Library.Dao.RI.Dao.NHibernate.Session;
using Bosphorus.Library.Dao.NHibernate.Model.Session;
using Bosphorus.Library.Dao.Core.Model.Session;
using Bosphorus.Library.Dao.Core.Extension.Model.Dao.Threaded;

namespace Bosphorus.Library.Dao.RI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Repository.Live.Load(this.GetType().Assembly, "DaoFactory.xml");
            Repository.Threaded.Load(this.GetType().Assembly, "ThreadedFactory.xml");

            Application.Idle += new EventHandler(Application_Idle);
        }

        private void GetAll1(IList<Account> list)
        {
            Console.WriteLine(list.Count);
        }

        private void GetAll2(IList<IncomingActualTransaction> list)
        {
            Console.WriteLine(list.Count);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //Console.WriteLine("Application Idle");
            //Repository.Threaded<Account>.CallbackTo(GetAll1).GetAll();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            //DaoFactory.AccountDao().GetAll();
            //Bosphorus.Library.Dao.RI.Entities.Account account = DaoFactory.AccountDao().LoadById("123456");
            //Bosphorus.Library.Dao.RI.Entities.Account account = DaoFactory.AccountDao().GetById("123456");
            IList<Account> list1 = DaoFactory.AccountDao().GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            ManualResetEvent[] doneEvents = new ManualResetEvent[2];
            doneEvents[0] = new ManualResetEvent(false);
            doneEvents[1] = new ManualResetEvent(false);

            ThreadStart threadStart1 = new ThreadStart(delegate() { DaoFactory.AccountDao().GetAll(); doneEvents[0].Set(); });
            ThreadStart threadStart2 = new ThreadStart(delegate() { DaoFactory.TempAccountDao().GetAll(); doneEvents[1].Set(); });

            Thread thread1 = new Thread(threadStart1);
            Thread thread2 = new Thread(threadStart2);

            thread1.Start();
            thread2.Start();

            WaitHandle.WaitAll(doneEvents);

            TimeSpan timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine("Threads completed.., {0}", timeSpan);
        }

        private void btnUnThreaded_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;

            DaoFactory.AccountDao().GetAll();
            DaoFactory.TempAccountDao().GetAll();

            TimeSpan timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine("Threads completed.., {0}", timeSpan);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            ManualResetEvent[] doneEvents = new ManualResetEvent[2];
            doneEvents[0] = new ManualResetEvent(false);
            doneEvents[1] = new ManualResetEvent(false);

            ThreadStart threadStart1 = new ThreadStart(delegate() { DaoFactory.IncomingActualTransactionDao().GetAll(); doneEvents[0].Set(); });
            ThreadStart threadStart2 = new ThreadStart(delegate() { DaoFactory.TempIncomingActualTransactionDao().GetAll(); doneEvents[1].Set(); });

            Thread thread1 = new Thread(threadStart1);
            Thread thread2 = new Thread(threadStart2);

            thread1.Start();
            thread2.Start();

            WaitHandle.WaitAll(doneEvents);

            TimeSpan timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine("Threads completed.., {0}", timeSpan);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;

            DaoFactory.IncomingActualTransactionDao().GetAll();
            DaoFactory.TempIncomingActualTransactionDao().GetAll();

            TimeSpan timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine("Threads completed.., {0}", timeSpan);
        }

        private void btnMultiThread_Click(object sender, EventArgs e)
        {
            Repository.Threaded<Account>.CallbackTo(GetAll1).GetAll();
            Repository.Threaded<IncomingActualTransaction>.CallbackTo(GetAll2).GetAll();
        }

        private void btnThreadAccount_Click(object sender, EventArgs e)
        {
            string sql = "Select Account from Account as Account";
            Repository.Threaded<Account>.CallbackTo(GetAll1).GetByQuery(sql);
        }

        private void btnThreadTransaction_Click(object sender, EventArgs e)
        {
            Repository.Threaded<Account>.CallbackTo(GetAll1).GetAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ISession session = Repository.Live.GetSession();
                using (ITransaction transaction = session.NewTransaction(IsolationLevel.ReadCommitted))
                {
                    Account account = Repository.Live<Account>.GetAll()[0];
                    Console.WriteLine(account.Department);
                    account.Department = (System.Guid.NewGuid().ToString().Substring(1, 10));
                    Repository.Live<Account>.SaveOrUpdate(account);
                    transaction.Rollback();
                    //throw new Exception();
                    //transaction.Commit();
                }
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThreadedResult accountResult = Repository.Threaded<Account>.GetAll();
            ThreadedResult transactionResult = Repository.Threaded<IncomingActualTransaction>.GetAll();

            ThreadSynchronizer.Synchronize(accountResult, transactionResult);

            Console.WriteLine(accountResult.Result);
            Console.WriteLine(transactionResult.Result);
        }

        private void btnSaveArray_Click(object sender, EventArgs e)
        {
            IList<Account> list = Repository.Live<Account>.GetAll();
            /*
            foreach (Account account in list)
            {
                account.BondTotal += 1;
            }
            */

            list[0].BondTotal += 1;
            list[1].BondTotal += 1;

            Repository.Live<Account>.Save(list[0], list[1]);
        }

        private void btnRepositoryObject_Click(object sender, EventArgs e)
        {
            Repository.Live.GetAll();
            Account account = new Account();

            Repository.Live.SaveOrUpdate(account);
        }
    }
}