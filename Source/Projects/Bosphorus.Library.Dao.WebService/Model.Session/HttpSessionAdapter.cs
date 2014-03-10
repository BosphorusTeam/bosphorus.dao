using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Session;

namespace Bosphorus.Library.Dao.WebService.Model.Session
{
    public class HttpSessionAdapter: ISession
    {
        public string Name
        {
            get { return "Default Http Session"; }
        }

        public ITransaction NewTransaction(IsolationLevel isolationLevel)
        {
            throw new TransactionNotAvailableException();
        }

        public object Clone()
        {
            return new HttpSessionAdapter();
        }

        public void Dispose()
        {
        }
    }
}
