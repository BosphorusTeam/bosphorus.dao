using System.Linq;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.Demo.Common.Business;
using Castle.Windsor;

namespace Bosphorus.Dao.Demo.ExecutionList.NHibernatee.Basic
{
    public class DaoCustomization: AbstractMethodExecutionItemList
    {
        private readonly IDao<Bank> genericDao;

        public DaoCustomization(IWindsorContainer container, IDao<Bank> genericDao) 
            : base(container)
        {
            this.genericDao = genericDao;
        }

        public IQueryable<Bank> StartsWith_ByExtension()
        {
            IQueryable<Bank> result = genericDao.GetStartsWithByExtension("Ci");
            return result;
        }
    }
}
