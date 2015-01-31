using Bosphorus.Dao.Core.Session.Provider.Factory;
using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.HbmMappingProvider
{
    public abstract class AbstractHbmMappingRegisterer : IHbmMappingRegisterer
    {
        private readonly string sessionAlias;

        protected AbstractHbmMappingRegisterer()
            : this(SessionAlias.Default)
        {
        }

        protected AbstractHbmMappingRegisterer(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
        }

        public void Apply(string sessionAlias, HbmMappingsContainer hbmMappingsContainer)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return;
            }

            Apply(hbmMappingsContainer);
        }

        protected abstract void Apply(HbmMappingsContainer hbmMappingsContainer);
    }
}