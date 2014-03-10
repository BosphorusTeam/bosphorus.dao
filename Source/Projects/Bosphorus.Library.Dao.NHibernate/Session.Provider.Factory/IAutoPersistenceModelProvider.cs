using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public interface IAutoPersistenceModelProvider
    {
        AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider);
    }
}
