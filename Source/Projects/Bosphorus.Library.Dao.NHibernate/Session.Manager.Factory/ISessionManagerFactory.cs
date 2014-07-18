using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public interface ISessionManagerFactory
    {
        ISessionManager Build(string sessionAlias);
    }
}
