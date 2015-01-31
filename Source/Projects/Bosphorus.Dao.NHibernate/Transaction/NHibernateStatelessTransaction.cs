namespace Bosphorus.Dao.NHibernate.Transaction
{
    public class NHibernateStatelessTransaction: AbstractTransaction
    {
        public NHibernateStatelessTransaction(global::NHibernate.ITransaction adapted) 
            : base(adapted)
        {
        }
    }
}
