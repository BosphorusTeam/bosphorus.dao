using Bosphorus.Dao.NHibernate.Demo.Log.Model;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo.Log.Dal.Configuration
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        public AutoPersistenceModelProvider()
            : base("LOG")
        {
        }

        protected override AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            return AutoMap
                .AssemblyOf<LogModel>()
                .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
