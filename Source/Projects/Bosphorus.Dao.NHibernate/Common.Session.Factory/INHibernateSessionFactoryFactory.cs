using NHibernate;

namespace Bosphorus.Dao.NHibernate.Common.Session.Factory
{
    public interface INHibernateSessionFactoryFactory
    {
        ISessionFactory Build(string sessionAlias);
    }
}
