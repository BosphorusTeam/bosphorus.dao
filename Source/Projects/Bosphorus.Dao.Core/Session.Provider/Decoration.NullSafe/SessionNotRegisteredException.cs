using Bosphorus.Dao.Core.Common;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Core.Session.Provider.Decoration.NullSafe
{
    internal class SessionNotRegisteredException : DaoException
    {
        private const string MESSAGE_FORMAT = "Session is not registered: [AliasName: {0}, SessionScope: {1}]";

        public SessionNotRegisteredException(string aliasName, SessionScope sessionScope)
            : base(string.Format(MESSAGE_FORMAT, aliasName, sessionScope))
        {
        }
    }
}