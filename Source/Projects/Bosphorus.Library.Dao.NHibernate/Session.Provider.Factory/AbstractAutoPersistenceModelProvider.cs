using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public abstract class AbstractAutoPersistenceModelProvider: IAutoPersistenceModelProvider
    {
        public virtual AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            IEnumerable<Assembly> allLoadedAssemblies = assemblyProvider.GetAssemblies();
            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModel(allLoadedAssemblies);
            return autoPersistenceModel;
        }

        protected virtual AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Assembly> allLoadedAssemblies)
        {
            IEnumerable<Type> allLoadedTypes = allLoadedAssemblies.SelectMany(assembly => assembly.GetTypes());
            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModel(allLoadedTypes);
            return autoPersistenceModel;
        }

        protected virtual AutoPersistenceModel GetAutoPersistenceModel(IEnumerable<Type> allLoadedAssemblies)
        {
            ITypeSource typeSource = new TypeSource(allLoadedAssemblies);
            return AutoMap.Source(typeSource);
        }
    }
}
