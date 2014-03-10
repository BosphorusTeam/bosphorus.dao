using NHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public interface IConfigurationProcessor
    {
        void Process(Configuration configuration);
    }
}
