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

namespace Demo.Facade.Vao
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Repository.View.Live.Loader.Load(Assembly.GetEntryAssembly(), "Demo.Facade.Vao.Repository.View.Live.xml");
            Repository.View.Cache.Loader.Load(Assembly.GetEntryAssembly(), "Demo.Facade.Vao.Repository.View.Cache.xml");
            Repository.View.Threaded.Loader.Load(Assembly.GetEntryAssembly(), "Demo.Facade.Vao.Repository.View.Threaded.xml");
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            IList<CustomerView> list = Repository.View.Live<CustomerView>.GetAll();
        }

        private void btnCache_Click(object sender, EventArgs e)
        {
            IList<CustomerView> list = Repository.View.Cache<CustomerView>.GetAll();
        }

        private void btnThreaded_Click(object sender, EventArgs e)
        {
            ThreadedListResult<CustomerView> threadedListResult = Repository.View.Threaded<CustomerView>.GetAll();

            ThreadSynchronizer.Synchronize(
                threadedListResult
            );

            IList<CustomerView> list = threadedListResult.Result;
        }

        private void btnThreaded2_Click(object sender, EventArgs e)
        {
            Repository.View.Threaded<CustomerView>.CallbackTo(Callback1).GetAll();
        }

        private void Callback1(IList<CustomerView> list)
        {
        }
    }
}