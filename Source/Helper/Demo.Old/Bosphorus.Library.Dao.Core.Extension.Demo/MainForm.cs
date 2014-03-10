using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bosphorus.Library.Dao.Core.Extension.Demo.Model;
using Bosphorus.Library.Dao.Core.Extension.Demo.Model.Core;
using Bosphorus.Library.Dao.Core.Extension.Model.Repository;
using Bosphorus.Library.Dao.Core.Model.Session;

namespace Bosphorus.Library.Dao.Core.Extension.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Repository.Live.Load(this.GetType().Assembly, "DaoFactory.xml");
            Repository.Cache.Load(this.GetType().Assembly, "CacheFactory.xml");
            Repository.Threaded.Load(this.GetType().Assembly, "ThreadedFactory.xml");

            ISession session = Repository.Live.GetSession();
            Console.WriteLine(session.Name);
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            //IList<Customer> list = Repository.Live<Customer>.GetAll();
            IList<object> list = Repository.Live<object>.GetAll();
        }

        private void btnGeneric_Click(object sender, EventArgs e)
        {
            IList<Account> list = Repository.Cache<Account>.GetAll();
        }

        private void btnCacheDecorator_Click(object sender, EventArgs e)
        {
            IList<Bank> list = Repository.Cache<Bank>.GetAll();
        }

        private void btnThreadDecorator_Click(object sender, EventArgs e)
        {
            //Repository.Treaded<Bank>.CallbackTo().GetAll(GetAll);
            Repository.Threaded<Bank>.CallbackTo(GetAll).GetAll();
        }

        private void GetAll(IList<Bank> list)
        {
            Console.WriteLine(list.Count);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            ISession session = Repository.Live.GetSession();
            using (ITransaction transaction = session.NewTransaction(IsolationLevel.ReadCommitted))
            {
                Repository.Live<Bank>.GetAll();
                transaction.Commit();
            }
        }
    }
}