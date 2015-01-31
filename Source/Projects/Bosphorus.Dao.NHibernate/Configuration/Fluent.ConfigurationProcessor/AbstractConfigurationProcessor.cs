using Bosphorus.Dao.Core.Session.Provider.Factory;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor
{
    public abstract class AbstractConfigurationProcessor : IConfigurationProcessor
    {
        private readonly string sessionAlias;

        protected AbstractConfigurationProcessor()
            : this(SessionAlias.Default)
        {
        }

        protected AbstractConfigurationProcessor(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
        }

        public void Process(string sessionAlias, global::NHibernate.Cfg.Configuration configuration)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return;
            }

            Process(configuration);
        }

        protected abstract void Process(global::NHibernate.Cfg.Configuration configuration);
    }
}