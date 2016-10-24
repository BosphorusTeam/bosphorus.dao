using System;
using Bosphorus.Dao.Core.Common;

namespace Bosphorus.Dao.Core.Session.Dao
{
    public class SessionTypeNotRegisteredException : DaoException
    {
        public SessionTypeNotRegisteredException(Type genericDaoType)
            : base($"SessionType is not registered for dao type: [{nameof(genericDaoType)}: {genericDaoType}]")
        {
        }
    }
}