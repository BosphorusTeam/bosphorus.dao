using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebService.Core.Model.Domain
{
    public class Account
    {
        private int no;
        private string name;
        private Guid guid;

        public Account()
        {
            guid = Guid.NewGuid();
        }

        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public int No
        {
            get { return no; }
            set { no = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
