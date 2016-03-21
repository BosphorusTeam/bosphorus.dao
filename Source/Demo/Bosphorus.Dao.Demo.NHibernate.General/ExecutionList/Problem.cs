using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Bosphorus.Dao.Demo.NHibernate.Common.Common;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.NHibernate.General.ExecutionList
{
    public class Problem: AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> dao;

        public Problem(IWindsorContainer container, IDao<Bank> dao)
            : base(container)
        {
            this.dao = dao;
        }

        public Bank Insert()
        {
            Bank bank = new Bank {No = "0092" };
            Bank result = dao.Insert(bank);
            return result;
        }

    }
}
