using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Session;

namespace Bosphorus.Library.Dao.Core.Extension.Demo.Model.Session
{
    public class MockSession: ISession
    {
        private string name;

        public MockSession()
            : this("Default")
        {
        }

        public MockSession(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            return new NullTransaction();
        }

        public object Clone()
        {
            return new MockSession(name);
        }

        public void Dispose()
        {
        }
    }
}
