using System;
using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.Core.Session
{
    public interface ISession: IDisposable
    {
        object NativeSession { get; }

        ITransaction NewTransaction(IsolationLevel isolationLevel);
    }
}
