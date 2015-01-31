using System.Collections.Generic;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.ConfigurationProcessor
{
    internal class CompositeConfigurationProcessor: IConfigurationProcessor
    {
        private readonly IList<IConfigurationProcessor> items;

        public CompositeConfigurationProcessor(IList<IConfigurationProcessor> items)
        {
            this.items = items;
        }

        public void Process(string sessionAlias, global::NHibernate.Cfg.Configuration configuration)
        {
            foreach (IConfigurationProcessor item in items)
            {
                item.Process(sessionAlias, configuration);
            }
        }
    }
}
