namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor
{
    public interface IConfigurationProcessor
    {
        void Process(string sessionAlias, global::NHibernate.Cfg.Configuration configuration);
    }
}
