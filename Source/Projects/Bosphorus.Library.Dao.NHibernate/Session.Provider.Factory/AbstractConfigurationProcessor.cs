using Bosphorus.Dao.NHibernate.Common;
using NHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
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

        public void Process(string sessionAlias, Configuration configuration)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return;
            }

            Process(configuration);
        }

        protected abstract void Process(Configuration configuration);
    }
}