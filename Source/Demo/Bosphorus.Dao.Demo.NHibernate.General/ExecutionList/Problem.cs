using Bosphorus.Demo.Runner.Executable;
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
