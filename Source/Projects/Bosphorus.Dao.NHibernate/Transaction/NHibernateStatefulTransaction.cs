namespace Bosphorus.Dao.NHibernate.Transaction
{
    public class NHibernateStatefulTransaction: AbstractTransaction
    {
        private readonly global::NHibernate.ISession session;

        public NHibernateStatefulTransaction(global::NHibernate.ITransaction adapted, global::NHibernate.ISession session) 
            : base(adapted)
        {
            this.session = session;
        }

        public override void Rollback()
        {
            base.Rollback();
            session.Clear();
        }
    }
}
