using Bosphorus.Dao.Core.Session.Manager;

namespace Bosphorus.Dao.NHibernate.Session.Manager.Factory
{
    public interface ISessionManagerFactory
    {
        ISessionManager Build(string sessionAlias);
    }
}
