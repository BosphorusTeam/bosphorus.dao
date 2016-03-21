using System;
using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.Core.Session
{
    public interface ISession
    {
        object NativeSession { get; }

        ITransaction NewTransaction(IsolationLevel isolationLevel);

        void Clear();

        void Flush();
    }
}
