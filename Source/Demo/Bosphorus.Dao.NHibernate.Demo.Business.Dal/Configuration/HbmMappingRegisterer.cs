using Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy;
using Bosphorus.Dao.NHibernate.Demo.Business.Model;
using Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider;
using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Configuration
{
    public class HbmMappingRegisterer : IHbmMappingRegisterer
    {
        public void Apply(string sessionAlias, HbmMappingsContainer hbmMappingsContainer)
        {
            hbmMappingsContainer.AddClasses(typeof(HbmMappingRegisterer));
        }
    }
}
