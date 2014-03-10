using System;
using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.Core.Session
{
    public interface ISession: IDisposable
    {
        ITransaction NewTransaction(IsolationLevel isolationLevel);
    }
}
