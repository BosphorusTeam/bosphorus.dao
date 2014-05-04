using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider
{
    public interface IAutoPersistenceModelProvider
    {
        AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider, string sessionAlias);
    }
}
