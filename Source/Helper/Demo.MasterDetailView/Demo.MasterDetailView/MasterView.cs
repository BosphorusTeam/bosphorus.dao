using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.MasterDetailView
{
    public class MasterView
    {
        private Master master;
        private IList<DetailView> detailViewList;

        public Master Master
        {
            get { return master; }
            set { master = value; }
        }

        public IList<DetailView> DetailViewList
        {
            get { return detailViewList; }
            set { detailViewList = value; }
        }
    }
}
