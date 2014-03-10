using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Demo.WebService.Core.Model.Domain;
using Bosphorus.Library.Dao.Facade;
using Bosphorus.Library.Facade;
using Bosphorus.Library.Facades;
using System.Reflection;
using Demo.WebService.Service.Dal.Model.Dao;
using Bosphorus.Library.Dao.Facade.Decoration.Threaded;

namespace Demo.WebService.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Repository.Domain.Live.Loader.Load("Demo.WebService.Dal.DaoFactory.xml", Assembly.Load("Demo.WebService.Dal"));
            //Repository.Domain.Cache.Loader.Load("Demo.WebService.Dal.CacheFactory.xml", Assembly.Load("Demo.WebService.Dal"));
            //Repository.Domain.Cache.Loader.Load()
            //Repository.Domain.Live.Loader.Load("Demo.WebService.Service.Dal.DaoFactory.xml", Assembly.Load("Demo.WebService.Service.Dal"));
        }

        public delegate object GetDataDelegate();

        private void SetDataSource(GetDataDelegate getDataDelegate)
        {
            Cursor current = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            DateTime startDate = DateTime.Now;
            object data = getDataDelegate();
            DateTime endDate = DateTime.Now;

            dataGrid1.DataSource = data;
            TimeSpan timeSpan = endDate.Subtract(startDate);
            Text = timeSpan.ToString();

            Cursor.Current = current;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            SetDataSource(Repository.Domain.Cache<Customer>.GetAll);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            SetDataSource(Repository.Domain.Live<Account>.GetAll);
        }

        private void btnAcccountCustomDao_Click(object sender, EventArgs e)
        {
            Account account1 = new Account();
            account1.No = 1;
            account1.Name = "Onur";

            Account account2 = new Account();
            account2.No = 2;
            account2.Name = "EKER";

            Repository.Domain.Live<Account>.Save(account1, account2);
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            SetDataSource(Repository.Domain.Live<Bank>.GetAll);
        }

    }
}