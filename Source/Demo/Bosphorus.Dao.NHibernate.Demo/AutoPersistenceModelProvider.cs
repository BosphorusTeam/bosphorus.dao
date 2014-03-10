using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo
{
    public class AutoPersistenceModelProvider: AbstractAutoPersistenceModelProvider
    {
        public override AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            return AutoMap.AssemblyOf<ExecutionItemList>().Where(type => 1 == 0);
        }
    }
}
