using Bosphorus.Configuration.Core;
using Bosphorus.Configuration.Default.InMemory;
using Bosphorus.Dao.Lucene.Session;
using Bosphorus.Dao.NHibernate.Session;

namespace Bosphorus.Dao.Demo.Common
{
    public class ParameterProvider: InMemoryParameterProvider, IParameterProvider
    {
        public ParameterProvider()
        {
            //SetValue("Bosphorus.Dao.Core.Session.Provider.Extension.DefaultSessionType", typeof(NHibernateStatefulSession));
            SetValue("Bosphorus.Dao.Core.Session.Provider.Extension.DefaultSessionType", typeof(LuceneSession));
        }
    }
}
