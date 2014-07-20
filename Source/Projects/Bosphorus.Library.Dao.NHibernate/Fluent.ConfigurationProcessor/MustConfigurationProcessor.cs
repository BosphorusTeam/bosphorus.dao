using Bosphorus.Dao.NHibernate.Session;
using NHibernate.Cfg;

namespace Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor
{
    public class MustConfigurationProcessor: AbstractConfigurationProcessor
    {
        protected override void Process(Configuration configuration)
        {
            string currentSessionContextImplTypeName = typeof(NHibernateCurrentSessionContext).FullName + ", " + typeof(NHibernateCurrentSessionContext).Assembly.FullName;  
            configuration.SetProperty(Environment.CurrentSessionContextClass, currentSessionContextImplTypeName);
        }
    }
}
