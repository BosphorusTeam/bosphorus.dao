using Bosphorus.Configuration.Default.InMemory;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    public class ParameterProvider: InMemoryParameterProvider
    {
        public ParameterProvider()
        {
            SetValue("Bosphorus.Dao.Core.Session.Provider.Extension.DefaultSessionType", typeof(NHibernateStatefulSession));
        }
    }
}
