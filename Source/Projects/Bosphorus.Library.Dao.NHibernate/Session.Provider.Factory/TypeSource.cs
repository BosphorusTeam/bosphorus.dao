using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Diagnostics;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public class TypeSource: ITypeSource
    {
        private readonly IEnumerable<Type> types;

        public TypeSource(Type type)
        {
            this.types = new List<Type> {type};
        }

        public TypeSource(IEnumerable<Type> types)
        {
            this.types = types;
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
            return "Predefined Types";
        }
    }
}
