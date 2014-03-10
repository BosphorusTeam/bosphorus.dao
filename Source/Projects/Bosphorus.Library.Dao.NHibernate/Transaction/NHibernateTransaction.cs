using Bosphorus.Dao.Core.Transaction;

namespace Bosphorus.Dao.NHibernate.Transaction
{
    public class NHibernateTransaction: ITransaction
    {
        private readonly global::NHibernate.ISession session;
        private readonly global::NHibernate.ITransaction adapted;

        public NHibernateTransaction(global::NHibernate.ITransaction adapted, global::NHibernate.ISession session)
        {
            this.session = session;
            this.adapted = adapted;
        }

        public void Commit()
        {
            adapted.Commit();
        }

        public void Rollback()
        {
            adapted.Rollback();
            session.Clear();
        }

        public void Dispose()
        {
            adapted.Dispose();
        }
    }
}
