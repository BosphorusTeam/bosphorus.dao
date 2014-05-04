using System;
using System.Collections.Generic;
using FluentNHibernate;
using FluentNHibernate.Diagnostics;

namespace Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider
{
    public class NullTypeSource: ITypeSource
    {
        private readonly IEnumerable<Type> types;

        public static ITypeSource Instance = new NullTypeSource();

        private NullTypeSource()
        {
            types = new List<Type>();
        }

        public IEnumerable<Type> GetTypes()
        {
            return types;
        }

        public void LogSource(IDiagnosticLogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            logger.LoadedFluentMappingsFromSource(this);
        }

        public string GetIdentifier()
        {
            return "Null Type Source";
        }
    }
}
