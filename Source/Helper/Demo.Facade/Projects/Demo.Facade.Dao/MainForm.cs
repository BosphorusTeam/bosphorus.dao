using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Bosphorus.Library.Dao.Facade;
using Bosphorus.Library.Dao.Facade.Decoration.Threaded;

namespace Demo.Facade.Dao
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Repository.Domain.Live.Loader.Load(Assembly.GetEntryAssembly(), "Demo.Facade.Dao.Repository.Domain.Live.xml");
            Repository.Domain.Cache.Loader.Load(Assembly.GetEntryAssembly(), "Demo.Facade.Dao.Repository.Domain.Cache.xml");
            Repository.Domain.Threaded.Loader.Load(Assembly.GetEntryAssembly(), "Demo.Facade.Dao.Repository.Domain.Threaded.xml");
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
        }

        private void btnCache_Click(object sender, EventArgs e)
        {
            IList<Customer> list = Repository.Domain.Cache<Customer>.GetAll();
        }

        private void btnThreaded_Click(object sender, EventArgs e)
        {
            ThreadedListResult<Customer> threadedListResult = Repository.Domain.Threaded<Customer>.GetAll();

            ThreadSynchronizer.Synchronize(
                threadedListResult
            );

            IList<Customer> list = threadedListResult.Result;
        }

        private void btnThreaded2_Click(object sender, EventArgs e)
        {
            Repository.Domain.Threaded<Customer>.CallbackTo(Callback1).GetAll();
        }

        private void Callback1(IList<Customer> list)
        {
        }
    }
}