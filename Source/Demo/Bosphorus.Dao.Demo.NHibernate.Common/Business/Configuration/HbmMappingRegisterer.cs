using Bosphorus.Dao.NHibernate.Configuration.Fluent.HbmMappingProvider;
using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business.Configuration
{
    public class HbmMappingRegisterer : IHbmMappingRegisterer
    {
        public void Apply(string sessionAlias, HbmMappingsContainer hbmMappingsContainer)
        {
            hbmMappingsContainer.AddClasses(typeof(HbmMappingRegisterer));
        }
    }
}
