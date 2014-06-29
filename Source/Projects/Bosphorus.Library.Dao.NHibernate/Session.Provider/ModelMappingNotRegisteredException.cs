using System;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Session.Provider
{
    public class ModelMappingNotRegisteredException : NHibernateDaoException
    {
        private const string MESSAGE_FORMAT = "Model mapping is not registed in session provider. [ModelClass: {0}, SessionAlias: {1}, SessionProvider: {2}]";

        public ModelMappingNotRegisteredException(ISessionProvider sessionProvider, Type modelType)
            : base(string.Format(MESSAGE_FORMAT, modelType, sessionProvider.SessionAlias, sessionProvider))
        {
        }
    }
}