using System.Collections.Generic;
using Castle.Core.Internal;
using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider
{
    internal class CompositeHbmMappingRegisterer : IHbmMappingRegisterer
    {
        private readonly IList<IHbmMappingRegisterer> items;

        public CompositeHbmMappingRegisterer(IList<IHbmMappingRegisterer> items)
        {
            this.items = items;
        }

        public void Apply(IAssemblyProvider assemblyProvider, HbmMappingsContainer hbmMappingsContainer)
        {
            foreach (IHbmMappingRegisterer item in items)
            {
                item.Apply(assemblyProvider, hbmMappingsContainer);
            }
        }
    }
}