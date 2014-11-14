namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory.Decoration
{
    public class CacheDecorator: Core.Session.Manager.Factory.Decoration.CacheDecorator, INHibernateSessionManagerFactory
    {
        public CacheDecorator(INHibernateSessionManagerFactory decorated) 
            : base(decorated)
        {
        }
    }
}
