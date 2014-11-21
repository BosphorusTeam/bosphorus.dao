using System;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Manager
{
    public class ModelMappingNotRegisteredException : NHibernateDaoException
    {
        private const string MESSAGE_FORMAT = "Model mapping is not registed in session provider. [ModelClass: {0}, SessionManager: {1}]";

        public ModelMappingNotRegisteredException(Type modelType, ISessionManager sessionManager)
            : base(string.Format(MESSAGE_FORMAT, modelType, sessionManager))
        {
        }
    }
}