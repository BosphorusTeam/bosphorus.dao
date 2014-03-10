namespace Bosphorus.Dao.Core.Transaction
{
    public class NullTransaction: ITransaction
    {
        public static NullTransaction Instance = new NullTransaction();

        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        public void Dispose()
        {
            Rollback();
        }
    }
}
