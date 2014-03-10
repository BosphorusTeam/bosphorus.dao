using Bosphorus.Dao.NHibernate.Demo.Model;
using Bosphorus.Dao.NHibernate.Session.Provider.Factory;
using FluentNHibernate.Automapping;

namespace Bosphorus.Dao.NHibernate.Demo
{
    public class AutoPersistenceModelProvider: IAutoPersistenceModelProvider
    {
        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            return AutoMap.AssemblyOf<ExecutionItemList>().Where(type => 1 == 0);
        }
    }
}
