using NHibernate;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory.Native
{
    public interface INHibernateSessionFactoryBuilder
    {
        ISessionFactory Build(string sessionAlias);
    }
}
