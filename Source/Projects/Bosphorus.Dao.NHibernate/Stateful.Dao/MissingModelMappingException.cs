using Bosphorus.Dao.Core.Session;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    public class MissingModelMappingException<TModel> : NHibernateDaoException
    {
        private const string MESSAGE_FORMAT = "Model mapping is not registed in session. [ModelClass: {0}, Session: {1}]";

        public MissingModelMappingException(ISession session)
            
            : base(string.Format(MESSAGE_FORMAT, typeof(TModel), session))
        {
        }
    }
}