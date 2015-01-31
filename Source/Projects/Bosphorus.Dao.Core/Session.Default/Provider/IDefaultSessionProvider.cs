using Bosphorus.Dao.Core.Dao;

namespace Bosphorus.Dao.Core.Session.Default.Provider
{
    public interface IDefaultSessionProvider
    {
        ISession Get<TModel>(IDao<TModel> dao, string sessionAlias);
    }
}
