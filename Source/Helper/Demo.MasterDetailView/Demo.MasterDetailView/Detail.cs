using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.MasterDetailView
{
    public class Detail
    {
        private int no;

        public Detail(int no)
        {
            this.no = no;
        }

        public int No
        {
            get { return no; }
            set { no = value; }
        }
	
    }
}
