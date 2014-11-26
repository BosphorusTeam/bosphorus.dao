using Bosphorus.Dao.Demo.Common.Log;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.Demo.NHibernate.Common.Log.Configuration
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
                .Where(type => type.Namespace == typeof(LogModel).Namespace)
                .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }
    }
}
