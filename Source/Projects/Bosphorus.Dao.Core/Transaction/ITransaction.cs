using System;

namespace Bosphorus.Dao.Core.Transaction
{
    public interface ITransaction: IDisposable
    {
        void Commit();

        void Rollback();
    }
}
