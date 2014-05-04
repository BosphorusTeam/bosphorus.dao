namespace Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor
{
    public interface IConfigurationProcessor
    {
        void Process(string sessionAlias, global::NHibernate.Cfg.Configuration configuration);
    }
}
