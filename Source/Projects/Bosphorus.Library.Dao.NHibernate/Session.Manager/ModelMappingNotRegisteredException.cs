using System;
using Bosphorus.Dao.Core.Session.Manager;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Manager
{
    public class ModelMappingNotRegisteredException : NHibernateDaoException
    {
        private const string MESSAGE_FORMAT = "Model mapping is not registed in session provider. [ModelClass: {0}, SessionAlias: {1}, SessionManager: {2}]";

        public ModelMappingNotRegisteredException(ISessionManager sessionManager, Type modelType)
            : base(string.Format(MESSAGE_FORMAT, modelType, sessionManager.SessionAlias, sessionManager))
        {
        }
    }
}