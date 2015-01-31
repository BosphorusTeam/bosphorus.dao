using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Dao.Core.Session.Provider.Factory;
using Castle.Core.Internal;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider
{
    public abstract class AbstractAutoPersistenceModelProvider: IAutoPersistenceModelProvider
    {
        private readonly string sessionAlias;
        private readonly AutoPersistenceModel nullAutoMap;

        protected AbstractAutoPersistenceModelProvider()
            : this(SessionAlias.Default)
        {
        }

        protected AbstractAutoPersistenceModelProvider(string sessionAlias)
        {
            this.sessionAlias = sessionAlias;
            this.nullAutoMap = AutoMap.Source(NullTypeSource.Instance);
        }

        public AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider, string sessionAlias)
        {
            if (sessionAlias != this.sessionAlias)
            {
                return nullAutoMap;
            }

            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModel(assemblyProvider);
            return autoPersistenceModel;
        }

        protected virtual AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            IEnumerable<Assembly> allLoadedAssemblies = assemblyProvider.GetAssemblies();
            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModel(allLoadedAssemblies);
            return autoPersistenceModel;
        }

        protected virtual AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Assembly> allLoadedAssemblies)
        {
            IEnumerable<Type> allLoadedTypes = allLoadedAssemblies.SelectMany(assembly => assembly.GetTypes());
            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModel(allLoadedTypes, SessionAlias.Default);
            return autoPersistenceModel;
        }

        protected virtual AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Type> allLoadedTypes, string sessionAlias)
        {
            ITypeSource typeSource = new TypeSource(allLoadedTypes);
            return AutoMap.Source(typeSource);
        }
    }
}
