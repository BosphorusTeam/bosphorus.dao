using Bosphorus.Common.Api.Symbol;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider
{
    public interface IAutoPersistenceModelProvider
    {
        AutoPersistenceModel GetAutoPersistenceModel(ITypeProvider typeProvider, string sessionAlias);
    }
}
