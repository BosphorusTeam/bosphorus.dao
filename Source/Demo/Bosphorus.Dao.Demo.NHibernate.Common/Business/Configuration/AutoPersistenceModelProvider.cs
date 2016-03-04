using System;
using System.Collections.Generic;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business.Configuration
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        protected override AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Type> allLoadedTypes, string sessionAlias)
        {
            return
                AutoMap
                    .AssemblyOf<Customer>()
                    .Where(type => type.Namespace == typeof(Customer).Namespace)
                    .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
