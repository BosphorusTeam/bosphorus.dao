using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Session.Provider.Factory
{
    public interface IAutoPersistenceModelProvider
    {
        AutoPersistenceModel GetAutoPersistenceModel();
    }
}
