using Bosphorus.Dao.NHibernate.Common;

namespace Bosphorus.Dao.NHibernate.Configuration.Fluent.PersistenceConfigurerProvider
{
    public class PersistenceConfigurerProviderNotFoundException : NHibernateDaoException
    {
        private const string MESSAGE_FORMAT = "IPersistenceConfigurerProvider not found for session alias. [SessionAlias: {0}]";

        public PersistenceConfigurerProviderNotFoundException(string sessionAlias)
            : base(string.Format(MESSAGE_FORMAT, sessionAlias))
        {
        }
    }
}