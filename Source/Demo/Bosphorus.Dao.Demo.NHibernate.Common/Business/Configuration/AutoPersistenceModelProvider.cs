using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.NHibernate.Configuration.Fluent.AutoPersistenceModelProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Business.Configuration
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        protected override AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            return
                AutoMap
                    .AssemblyOf<Customer>()
                    .Where(type => type.Namespace == typeof(Customer).Namespace)
                    .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
