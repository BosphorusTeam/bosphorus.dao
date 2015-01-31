using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.NHibernate.Transaction
{
    public abstract class AbstractTransaction: ITransaction
    {
        private readonly global::NHibernate.ITransaction adapted;

        protected AbstractTransaction(global::NHibernate.ITransaction adapted)
        {
            this.adapted = adapted;
        }

        public virtual void Commit()
        {
            adapted.Commit();
        }

        public virtual void Rollback()
        {
            adapted.Rollback();
        }

        public virtual void Dispose()
        {
            adapted.Dispose();
        }
    }
}
