using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.HbmMappingProvider
{
    public interface IHbmMappingRegisterer
    {
        void Apply(string sessionAlias, HbmMappingsContainer hbmMappingsContainer);
    }
}
