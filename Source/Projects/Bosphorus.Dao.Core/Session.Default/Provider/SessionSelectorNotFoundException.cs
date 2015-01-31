using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Dao;

namespace Bosphorus.Dao.Core.Session.Default.Provider
{
    public class SessionSelectorNotFoundException<TModel> : DaoException
    {
        public SessionSelectorNotFoundException(IDao<TModel> dao)
        {
        }

    }
}