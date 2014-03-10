using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo.MasterDetailView
{
    public partial class MainForm : Form
    {
        private MasterVao masterVao = new MasterVao();
        private DetailVao detailVao = new DetailVao();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btMasterVao_Click(object sender, EventArgs e)
        {
            IList<MasterView> list = masterVao.GetAll();
        }

        private void btnDetailVao_Click(object sender, EventArgs e)
        {
            IList<DetailView> list = detailVao.GetAll();
        }
    }
}