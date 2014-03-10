using Bosphorus.Dao.Core.Session.Provider;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public interface ISessionProviderFactory
    {
        ISessionProvider Build(string sessionAlias);
    }
}
