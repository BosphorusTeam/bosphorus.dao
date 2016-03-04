using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList
{
    public class Problem: AbstractMethodExecutionItemList
    {
        public Problem(IWindsorContainer container) 
            : base(container)
        {
        }
    }
}
