using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public abstract class AbstractAutoPersistenceModelProvider: IAutoPersistenceModelProvider
    {
        public AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            AutoPersistenceModel autoPersistenceModel = GetAutoPersistenceModelInternal(assemblyProvider);
            return autoPersistenceModel;
        }

        protected abstract AutoPersistenceModel GetAutoPersistenceModelInternal(IAssemblyProvider assemblyProvider);
    }
}
