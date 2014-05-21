using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Configuration
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        protected override AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            return
                AutoMap
                    .AssemblyOf<Customer>()
                    .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
