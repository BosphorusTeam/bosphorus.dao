using NHibernate;

namespace Bosphorus.Dao.NHibernate.Common.Session.Factory
{
    public interface INHibernateSessionFactoryBuilder
    {
        ISessionFactory Build(string sessionAlias);
    }
}
