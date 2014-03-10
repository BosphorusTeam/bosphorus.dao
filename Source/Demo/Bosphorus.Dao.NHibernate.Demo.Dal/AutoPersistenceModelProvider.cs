using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo.Dal
{
    public class AutoPersistenceModelProvider: IAutoPersistenceModelProvider
    {
        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            return AutoMap.AssemblyOf<Customer>().UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
