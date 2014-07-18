using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
{
    public interface ISessionManagerFactory
    {
        ISessionManager Build(string sessionAlias);
    }
}
