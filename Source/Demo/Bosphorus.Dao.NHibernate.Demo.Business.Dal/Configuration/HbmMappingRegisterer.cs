using System;
using Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy;
using Bosphorus.Dao.NHibernate.Fluent.HbmMappingProvider;
using Castle.Core.Internal;
using FluentNHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Configuration
{
    public class HbmMappingRegisterer : IHbmMappingRegisterer
    {
        public void Apply(IAssemblyProvider assemblyProvider, HbmMappingsContainer hbmMappingsContainer)
        {
            hbmMappingsContainer.AddClasses(typeof(ImportCargoInfoServiceMap));
        }
    }
}
