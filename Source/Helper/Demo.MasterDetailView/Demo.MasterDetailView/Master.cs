using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.MasterDetailView
{
    public class Master
    {
        private int no;
        private string name;

        public Master(int no, string name)
        {
            this.no = no;
            this.name = name;
            detailList = new List<Detail>();
            detailList.Add(new Detail(1));
        }

        private IList<Detail> detailList;

        public IList<Detail> DetailList
        {
            get { return detailList; }
            set { detailList = value; }
        }
	

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
	
        public int No
        {
            get { return no; }
            set { no = value; }
        }
	
    }
}
