using System;
using System.Collections.Generic;
using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Log.Configuration
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        public AutoPersistenceModelProvider()
            : base("LOG")
        {
        }

        protected override AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Type> allLoadedTypes, string sessionAlias)
        {
            return AutoMap
                .AssemblyOf<LogModel>()
                .Where(type => type.Namespace == typeof(LogModel).Namespace)
                .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
