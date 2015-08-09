using System;
using Bosphorus.Dao.Core.Common;

namespace Bosphorus.Dao.Core.Session.Repository
{
    public class SessionRepositoryNotRegistered : DaoException
    {
        private const string MESSAGE_FORMAT = "Session repository is not registered for scope: [SessionScope: {0}]";

        public SessionRepositoryNotRegistered(SessionScope sessionScope)
            : base(string.Format(MESSAGE_FORMAT, sessionScope))
        {
        }
    }
}