using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo.Dal
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        protected override AutoPersistenceModel GetAutoPersistenceModelInternal(IAssemblyProvider assemblyProvider)
        {
            return AutoMap.AssemblyOf<Customer>().UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
