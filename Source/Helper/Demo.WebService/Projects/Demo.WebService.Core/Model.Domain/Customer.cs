using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebService.Core.Model.Domain
{
    public class Customer
    {
        private int no;
        private string name;

        public Customer()
        {
        }

        public Customer(int no, string name)
        {
            this.no = no;
            this.name = name;
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

        public override string ToString()
        {
            return name;
        }
	
    }
}
