using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Dao.NHibernate.Demo.Log.Model;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo.Log.Dal.Configuration
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        public AutoPersistenceModelProvider()
            : base("LOG")
        {
        }

        protected override AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Type> allLoadedTypes, string sessionAlias)
        {
            return base.GetAutoPersistenceModel(allLoadedTypes.Where(type => type == typeof(LogModel)), sessionAlias);
        }
    }
}
