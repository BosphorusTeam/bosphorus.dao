using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Dao
{
    public class ModelMappingNotRegisteredException<TModel> : NHibernateDaoException
    {
        private const string MESSAGE_FORMAT = "Model mapping is not registed in session provider. [ModelClass: {0}, SessionAlias: {1}, SessionProvider: {2}]";

        public ModelMappingNotRegisteredException(ISessionProvider sessionProvider)
            : base(string.Format(MESSAGE_FORMAT, typeof(TModel), sessionProvider.SessionAlias, sessionProvider))
        {
        }
    }
}