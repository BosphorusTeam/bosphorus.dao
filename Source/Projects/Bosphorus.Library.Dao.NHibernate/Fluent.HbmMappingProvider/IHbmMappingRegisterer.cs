using Castle.Core.Internal;
using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider
{
    public interface IHbmMappingRegisterer
    {
        void Apply(string sessionAlias, HbmMappingsContainer hbmMappingsContainer);
    }
}
